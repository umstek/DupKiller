using System;
using System.Collections.Generic;
using DupKiller;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class TestCore
    {
        private const string Prefix = "x";
        private static readonly Func<string, string> GroupFunc = str => str.Substring(0, 2);

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