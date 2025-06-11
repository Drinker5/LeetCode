using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace LeetCode.Problems
{
    public class _14_LongestCommonPrefix
    {
        private readonly Solution solution;

        public _14_LongestCommonPrefix()
        {
            solution = new Solution();
        }

        public class Solution
        {
            public string LongestCommonPrefix(string[] strs)
            {
                var resi = 999;
                var etalon = strs[0];
                foreach (var str in strs)
                {
                    var prefix = -1;
                    for (var i = 0; i < etalon.Length; i++)
                    {
                        if (str.Length <= i)
                            break;

                        if (etalon[i] == str[i])
                        {
                            prefix = Math.Max(prefix, i);
                        }
                        else break;
                    }

                    resi = Math.Min(resi, prefix);
                }

                return etalon.Substring(0, resi + 1);
            }
        }

        [Fact]
        public void Solver()
        {
            var result = solution.LongestCommonPrefix(["cir", "car"]);
            Assert.Equal("c", result);
        }

        public class Data : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return [new string[] { "cir", "car" }, "c"];
                yield return [new string[] { "flower", "flow", "flight" }, "fl"];
                yield return [new string[] { "flower" }, "flower"];
                yield return [new string[] { "dog", "racecar", "car" }, ""];
                yield return [new string[] { "" }, ""];
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        [Theory]
        [ClassData(typeof(Data))]
        public void Theory(string[] input, string output)
        {
            var result = solution.LongestCommonPrefix(input);
            Assert.Equal(output, result);
        }
    }
}