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
        private static readonly Func<string, string> GroupFunc1 = str => str.Length.ToString();
        private static readonly Func<string, string> GroupFunc2 = str => str.Substring(0, 1).ToString();

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

        private static readonly IList<string> Examples1 = new List<string>
        {
            "000",
            "001",
            "010",
            "011",
            "100",
            "101",
            "110",
            "111",
            "0000",
            "0001",
            "0010",
            "0011",
            "0100",
            "0101",
            "0110",
            "0111",
            "1000",
            "1001",
            "1010",
            "1011",
            "1100",
            "1101",
            "1110",
            "1111"
        };

        private static readonly Dictionary<string, IList<string>> DuplicatesIndex =
            new Dictionary<string, IList<string>>
            {
                { "3:0:00", new List<string> { "000", "001" } },
                { "3:0:01", new List<string> { "010", "011" } },
                { "3:1:10", new List<string> { "100", "101" } },
                { "3:1:11", new List<string> { "110", "111" } },

                { "4:0:00", new List<string> { "0000", "0001", "0010", "0011" } },
                { "4:0:01", new List<string> { "0100", "0101", "0110", "0111" } },
                { "4:1:10", new List<string> { "1000", "1001", "1010", "1011" } },
                { "4:1:11", new List<string> { "1100", "1101", "1110", "1111" } }
            };

        private readonly ITestOutputHelper _output;

        public TestCore(ITestOutputHelper output)
        {
            _output = output;
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

        [Theory]
        [MemberData(nameof(BuildDuplicatesIndexTestCases))]
        public void TestBuildDuplicatesIndex(IDictionary<string, IList<string>> duplicatesIndex,
            IEnumerable<string> items)
        {
            var actual = typeof(Core).ExecutePrivateStaticMethod("BuildDuplicatesIndex",
                new object[]
                {
                    items,
                    new List<Func<string, string>>
                    {
                        GroupFunc1,
                        GroupFunc2,
                        GroupFunc
                    },
                    ""
                });
            foreach (var (key, value) in (IDictionary<string, IList<string>>)actual)
                _output.WriteLine($"{key}: {string.Join(", ", value)}");

            Assert.Equal(duplicatesIndex, actual);
        }

        // ReSharper disable MemberCanBePrivate.Global
        public static IEnumerable<object[]> GroupByTestCases => new List<object[]>
        {
            new object[] { Groups, Examples }
        };

        public static IEnumerable<object[]> TakeOnlyDuplicatesTestCases => new List<object[]>
        {
            new object[] { DuplicateGroups, Groups }
        };

        public static IEnumerable<object[]> PrefixGroupsTestCases => new List<object[]>
        {
            new object[] { PrefixedGroups, DuplicateGroups }
        };

        public static IEnumerable<object[]> BuildDuplicatesIndexTestCases => new List<object[]>
        {
            new object[] { DuplicatesIndex, Examples1 }
        };
        // ReSharper restore MemberCanBePrivate.Global
    }
}