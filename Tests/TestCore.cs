using System;
using System.Collections.Generic;
using System.IO.Abstractions.TestingHelpers;
using DupKiller;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class TestCore
    {
        private const string Prefix = "x";
        private static readonly Func<string, string> GroupFunc = str => str.Substring(0, 2);

        private static readonly Core MockedCore = new Core(
            new MockFileSystem(
                new Dictionary<string, MockFileData>
                {
                    { @"A:\test\alpha\file.txt", new MockFileData("Test file") },
                    { @"B:\test\beta\file.txt", new MockFileData("Another test file") },
                    { @"C:\test\gamma\file.bin", new MockFileData(new byte[] { 0x12, 0x34, 0x56, 0xd2 }) }
                }
            )
        );

        private static readonly List<string> Examples = new List<string>
        {
            "love",
            "code",
            "alpha",
            "algebra",
            "algorithm",
            "cog",
            "alpine",
            "lonely",
            "magic",
            "horse"
        };

        private static readonly Dictionary<string, IList<string>> Groups = new Dictionary<string, IList<string>>
        {
            { "lo", new List<string> { "love", "lonely" } },
            { "co", new List<string> { "code", "cog" } },
            { "al", new List<string> { "alpha", "algebra", "algorithm", "alpine" } },
            { "ma", new List<string> { "magic" } },
            { "ho", new List<string> { "horse" } }
        };


        private static readonly Dictionary<string, IList<string>> DuplicateGroups =
            new Dictionary<string, IList<string>>
            {
                { "lo", new List<string> { "love", "lonely" } },
                { "co", new List<string> { "code", "cog" } },
                { "al", new List<string> { "alpha", "algebra", "algorithm", "alpine" } }
            };

        private static readonly Dictionary<string, IList<string>> PrefixedGroups =
            new Dictionary<string, IList<string>>
            {
                { "x:lo", new List<string> { "love", "lonely" } },
                { "x:co", new List<string> { "code", "cog" } },
                { "x:al", new List<string> { "alpha", "algebra", "algorithm", "alpine" } }
            };

        private readonly ITestOutputHelper _output;

        public TestCore(ITestOutputHelper output)
        {
            _output = output;
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public static IEnumerable<object[]> GroupByTestCases => new List<object[]>
        {
            new object[] { Groups, Examples }
        };

        // ReSharper disable once MemberCanBePrivate.Global
        public static IEnumerable<object[]> TakeOnlyDuplicatesTestCases => new List<object[]>
        {
            new object[] { DuplicateGroups, Groups }
        };

        // ReSharper disable once MemberCanBePrivate.Global
        public static IEnumerable<object[]> PrefixGroupsTestCases => new List<object[]>
        {
            new object[] { PrefixedGroups, DuplicateGroups }
        };

        [Theory]
        [InlineData("", @"A:/whateverpath/filename")]
        [InlineData(".ext", @"B:/whateverpath/.ext")]
        [InlineData(".ext", @"B:/whateverpath/filename.ext")]
        [InlineData("", @"C:/whateverpath/")]
        public void TestGetExtension(string extension, string path)
        {
            Assert.Equal(
                extension,
                MockedCore.ExecutePrivateMethod("GetExtension", new object[] { path })
            );
        }

        [Theory]
        [InlineData("filename", @"A:/whateverpath/filename")]
        [InlineData("", @"B:/whateverpath/.ext")]
        [InlineData("filename", @"B:/whateverpath/filename.ext")]
        [InlineData("", @"C:/whateverpath/")]
        public void TestGetFileName(string fileName, string path)
        {
            Assert.Equal(
                fileName,
                MockedCore.ExecutePrivateMethod("GetFileName", new object[] { path })
            );
        }

        [Theory]
        [InlineData("9", @"A:/test/alpha/file.txt")]
        [InlineData("4", @"C:/test/gamma/file.bin")]
        public void TestGetFileSize(string length, string path)
        {
            Assert.Equal(
                length,
                MockedCore.ExecutePrivateMethod("GetFileSize", new object[] { path })
            );
        }

        [Theory]
        [InlineData("7ckAdFxdFddz+83As3bwDA==", @"A:/test/alpha/file.txt")]
        [InlineData("7DY/LTZvMO/gSAwDOQj0Pw==", @"C:\test\gamma\file.bin")]
        public void TestGetShortHash(string md5, string path)
        {
            Assert.Equal(
                md5,
                MockedCore.ExecutePrivateMethod("GetShortHash", new object[] { path })
            );
        }

        [Theory]
        [InlineData("aRhaZl7LiPMznPzRr87uoFSjdXNWmG4G+mXb8ElwBeJIF2bft0NhK6Ueg2URakz/5L8Jxh+gztgdf7XsQBwsWg==",
            @"C:/test/gamma/file.bin")]
        public void TestGetLongHash(string sha512, string path)
        {
            Assert.Equal(
                sha512,
                MockedCore.ExecutePrivateMethod("GetLongHash", new object[] { path })
            );
        }

        [Theory]
        [MemberData(nameof(GroupByTestCases))]
        public void TestGroupBy(IDictionary<string, IList<string>> groups, List<string> items)
        {
            var actual = typeof(Core).ExecutePrivateStaticMethod("GroupBy", new object[] { items, GroupFunc });
            foreach (var (key, value) in (IDictionary<string, IList<string>>)actual)
                _output.WriteLine($"{key}: {string.Join(", ", value)}");

            Assert.Equal(groups, actual);
        }

        [Theory]
        [MemberData(nameof(TakeOnlyDuplicatesTestCases))]
        public void TestTakeOnlyDuplicates(IDictionary<string, IList<string>> duplicateGroups,
            IDictionary<string, IList<string>> groups)
        {
            var actual = typeof(Core).ExecutePrivateStaticMethod("TakeOnlyDuplicates", new object[] { groups });
            foreach (var (key, value) in (IDictionary<string, IList<string>>)actual)
                _output.WriteLine($"{key}: {string.Join(", ", value)}");

            Assert.Equal(duplicateGroups, actual);
        }

        [Theory]
        [MemberData(nameof(PrefixGroupsTestCases))]
        public void TestPrefixGroups(IDictionary<string, IList<string>> prefixedGroups,
            IDictionary<string, IList<string>> duplicateGroups)
        {
            var actual =
                typeof(Core).ExecutePrivateStaticMethod("PrefixGroups", new object[] { duplicateGroups, Prefix });
            foreach (var (key, value) in (IDictionary<string, IList<string>>)actual)
                _output.WriteLine($"{key}: {string.Join(", ", value)}");

            Assert.Equal(prefixedGroups, actual);
        }
    }
}