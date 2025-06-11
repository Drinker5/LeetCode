using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;

namespace LeetCode.Problems
{
    public class _15_3Sum
    {
        private readonly Solution solution;

        public _15_3Sum()
        {
            solution = new Solution();
        }

        public class Solution
        {
            public IList<IList<int>> ThreeSum(int[] nums)
            {
                var result = new HashSet<(int, int, int)>();
                Array.Sort(nums);
                for (int i = 0; i < nums.Length - 2; i++)
                {
                    var duplets = Duplets(nums, -nums[i], i);
                    foreach (var duplet in duplets)
                    {
                        result.Add((nums[i], duplet.Item1, duplet.Item2));
                    }
                }

                var x = result.Select(IList<int> (i) => new List<int> { i.Item1, i.Item2, i.Item3 }).ToList();
                return x;
            }

            public HashSet<(int, int)> Duplets(int[] nums, int checkSum, int start)
            {
                var l = start + 1;
                var r = nums.Length - 1;
                var result = new HashSet<(int, int)>();
                while (l < r)
                {
                    var sum = nums[l] + nums[r];
                    if (sum == checkSum)
                        result.Add((nums[l], nums[r]));

                    if (sum > checkSum)
                        r--;
                    else
                        l++;
                }

                return result;
            }
        }

        public class Data : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return
                [
                    new int[] { -1, 0, 1, 2, -1, 4 }, new List<List<int>>
                    {
                        new List<int> { -1, -1, 2 },
                        new List<int> { -1, 0, 1 },
                    }
                ];
                yield return [new int[] { 0, 1, 1 }, new List<List<int>> { }];
                yield return [new int[] { 0, 0, 0 }, new List<List<int>> { new List<int> { 0, 0, 0 } }];
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        [Theory]
        [ClassData(typeof(Data))]
        public void Theory(int[] input, List<List<int>> output)
        {
            var result = solution.ThreeSum(input);
            Assert.Equal(output.Count, result.Count);
            foreach (var item in result)
                Assert.Contains(item, output);
        }
    }
}