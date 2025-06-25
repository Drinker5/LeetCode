namespace LeetCode.Problems;

public class _2654_Minimum_Number_of_Operations_to_Make_All_Array_Elements_Equal_to_1
{
    public class Solution
    {
        public int MinOperations(int[] nums)
        {
            int ones = 0;
            for (int i = 0; i < nums.Length; i++)
                if (nums[i] == 1) ones++;

            if (ones > 0)
                return nums.Length - ones;

            var ans = int.MaxValue;
            for (int i = 0; i < nums.Length; i++)
            {
                var l = nums[i];
                for (int j = i + 1; j < nums.Length; j++)
                {
                    l = Gcd(l, nums[j]);
                    if (l == 1)
                        ans = Math.Min(ans, j - i);
                }
            }
            
            if (ans == int.MaxValue) {
                return -1;
            }

            return ans + nums.Length - 1;
        }

        int Gcd(int a, int b)
        {
            return b == 0 ? a : Gcd(b, a % b);
        }
    }

    private readonly Solution s = new();

    private class Data : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return [new int[] { 2, 6, 3, 4 }, 4];
            yield return [new int[] { 2, 10, 6, 14 }, -1];
            yield return [new int[] { 1, 2 }, 1];
            yield return [new int[] { 1000, 999 }, 2];
            yield return [new int[] { 6, 10, 15 }, 4];
            yield return [new int[] { 1, 10, 15, 3 }, 3];
            yield return [new int[] { 1,1 }, 0];
        }
    }

    [Theory]
    [ClassData(typeof(Data))]
    public void Theory(int[] nums, int output)
    {
        var result = s.MinOperations(nums);
        Assert.Equal(output, result);
    }
}