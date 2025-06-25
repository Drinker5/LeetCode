namespace LeetCode.Problems
{
    public class _16_3SumClosest
    {
        private readonly Solution solution;

        public _16_3SumClosest()
        {
            solution = new Solution();
        }

        public class Solution
        {
            public int ThreeSumClosest(int[] nums, int target)
            {
                var result = int.MaxValue;
                Array.Sort(nums);
                var pos = (0, 0, 0);
                for (int i = 0; i < nums.Length - 2; i++)
                {
                    var nearest = NearDuplet(nums, nums[i], target, i);
                    if (Math.Abs(nearest.Item1) < Math.Abs(result))
                    {
                        result = nearest.Item1;
                        pos = (i, nearest.Item2, nearest.Item3);
                    }
                }

                return nums[pos.Item1] + nums[pos.Item2] + nums[pos.Item3];
            }

            public (int, int, int) NearDuplet(int[] nums, int checkSum, int target, int start)
            {
                var l = start + 1;
                var r = nums.Length - 1;
                var result = int.MaxValue;
                (int, int) pos = (l, r);
                while (l < r)
                {
                    var sum = checkSum + nums[l] + nums[r];
                    if (Math.Abs(sum) - Math.Abs(target) < Math.Abs(result))
                    {
                        result = sum - target;
                        pos = (l, r);
                    }

                    if (result == 0)
                        break;

                    if (sum > target)
                        r--;
                    else
                        l++;
                }

                return (result, pos.Item1, pos.Item2);
            }
        }

        public class Data : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return [new int[] { -1, 2, 1, -4 }, 1, 2];
                yield return [new int[] { 0, 0, 0 }, 1, 0];
                yield return [new int[] { 0, 3, 97, 102, 200 }, 300, 300];
                yield return [new int[] { 0, 1, 1, 0, 1 }, 3, 3];
                yield return [new int[] { 2, 3, 8, 9, 10 }, 16, 15];
                yield return [new int[] { 4, 0, 5, -5, 3, 3, 0, -4, -5 }, -2, -2];
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        [Theory]
        [ClassData(typeof(Data))]
        public void Theory(int[] input, int target, int output)
        {
            var result = solution.ThreeSumClosest(input, target);
            Assert.Equal(output, result);
        }
    }
}