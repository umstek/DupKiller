using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace DupKiller
{
    public static class Core
    {
        private static IDictionary<string, Func<string, string>> GroupingFunctions { get; } =
            new Dictionary<string, Func<string, string>>
            {
                {"Extension", GetExtension},
                {"FileName", GetFileName},
                {"FileSize", GetFileSize},
                {"ShortHash", GetShortHash},
                {"LongHash", GetLongHash}
            };

        // A perfect duplicate files finder would have to compare the content of each file with the 
        // content of everything else. This has a O(n^2) complexity, and since the files can be 
        // large, this is not possible and will take a long time to complete. If a dictionary i.e.: 
        // a hashmap can be created with the content as keys and paths as values, we can identify 
        // duplicate files quickly. But this is neither a viable option because all the files will 
        // have to be stored in memory and a dictionary will not work properly with that. 
        // Most of the current software use file size and extension to find the duplicate files but 
        // this can be inaccurate in various instances e.g.: uncompressed images that are the same 
        // size. 
        // So, the best option is to consider multiple factors, and allow user to select whether to 
        // use them. These factors should include a hash function. If the user suspects a hash 
        // collision, there should be a way to raw compare the files. Since we have filtered 
        // possible duplicates by various means, such incident can rarely occur. 

        // Group by extension (optional default yes), file name (optional default no), 
        // file size, shorter hash (MD5), longer hash (SHA512)

        private static string GetExtension(string file)
        {
            return Path.GetExtension(file);
        }

        private static string GetFileName(string file)
        {
            return Path.GetFileName(file);
        }

        private static string GetFileSize(string file)
        {
            return new FileInfo(file).Length.ToString();
        }

        private static string GetShortHash(string file)
        {
            using (var md5 = MD5.Create())
            using (var stream = File.OpenRead(file))
            {
                return Convert.ToBase64String(md5.ComputeHash(stream));
            }
        }

        private static string GetLongHash(string file)
        {
            using (var sha512 = SHA512.Create())
            using (var stream = File.OpenRead(file))
            {
                return Convert.ToBase64String(sha512.ComputeHash(stream));
            }
        }

        private static IDictionary<string, IList<string>> GroupBy(IEnumerable<string> files, Func<string, string> func)
        {
            var groups = new Dictionary<string, IList<string>>();
            foreach (var file in files)
            {
                var fact = func(file);
                if (!groups.ContainsKey(fact)) groups[fact] = new List<string>();
                groups[fact].Add(file);
            }

            return groups;
        }

        private static IDictionary<string, IList<string>> TakeOnlyDuplicates(IDictionary<string, IList<string>> groups)
        {
            var duplicateGroups = new Dictionary<string, IList<string>>();
            foreach (var key in groups.Keys)
                if (groups[key].Count > 1)
                    duplicateGroups[key] = groups[key];

            return duplicateGroups;
        }

        private static IDictionary<string, IList<string>> PrefixGroups(IDictionary<string, IList<string>> groups,
            string prefix)
        {
            var prefixedGroups = new Dictionary<string, IList<string>>();
            foreach (var key in groups.Keys) prefixedGroups[$"{prefix}:{key}"] = groups[key];

            return prefixedGroups;
        }

        private static IDictionary<string, IList<string>> BuildDuplicatesIndex(
            IEnumerable<string> files,
            IList<GroupingCriteria> criteria,
            int criterionIndex = 0,
            string prefix = ""
        )
        {
            var groups = GroupBy(files, GroupingFunctions[criteria[criterionIndex].ToString()]);
            var duplicateGroups = TakeOnlyDuplicates(groups);

            if (criterionIndex + 1 < criteria.Count)
            {
                var flattenedGroups = new Dictionary<string, IList<string>>();
                foreach (var duplicateGroup in duplicateGroups)
                {
                    var innerGroups = BuildDuplicatesIndex(duplicateGroup.Value, criteria, criterionIndex + 1,
                        duplicateGroup.Key);
                    foreach (var key in innerGroups.Keys) flattenedGroups[key] = innerGroups[key];
                }

                duplicateGroups = flattenedGroups;
            }

            var prefixedGroups = string.IsNullOrEmpty(prefix) ? duplicateGroups : PrefixGroups(duplicateGroups, prefix);

            return prefixedGroups;
        }

        private enum GroupingCriteria
        {
            Extension,
            FileName,
            FileSize,
            ShortHash,
            LongHash
        }
    }
}