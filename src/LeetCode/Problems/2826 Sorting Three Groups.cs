namespace LeetCode.Problems;

public class _2826_Sorting_Three_Groups
{
    public class Solution
    {
        public int MinimumOperations(IList<int> nums)
        {
            var arr = new int[nums.Count];
            var cnt = 0;
            var result = int.MaxValue;
            for (int i = 0; i <= nums.Count; i++)
            {
                for (int j = i; j <= nums.Count; j++)
                {
                    for (int k = 0; k < i; k++)
                        arr[k] = 1;
                    for (int k = i; k < j; k++)
                        arr[k] = 2;
                    for (int k = j; k < nums.Count; k++)
                        arr[k] = 3;

                    cnt = 0;
                    for (int k = 0; k < nums.Count; k++)
                    {
                        if (arr[k] != nums[k]) cnt++;
                    }
                    
                    result = Math.Min(result, cnt);
                }
            }

            return result;
        }
    }

    private readonly Solution s = new();

    private class Data : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return [new[] { 2, 1, 3, 2, 1 }, 3];
            yield return [new[] { 1, 2, 3, 1, 2, 3 }, 2];
            yield return [new[] { 1, 3, 2, 1, 3, 3 }, 2];
            yield return [new[] { 2, 2, 2, 2, 3, 3 }, 0];
            yield return [new[] { 3, 3, 2, 2, 2, 2 }, 2];
            yield return [new[] { 1, 2, 1, 1, 1, 1 }, 1];
            yield return [new[] { 1, 2, 3, 1, 1, 1, 1 }, 2];
            yield return [new[] { 1, 3, 2, 1, 1, 1, 1 }, 2];
            yield return [new[] { 2, 1, 1, 1, 1, 1 }, 1];
            yield return [new[] { 3, 3, 3, 3, 3, 1 }, 1];
            yield return [new[] { 2, 1, 1, 2, 1, 1 }, 2];
            yield return [new[] { 1, 1, 1, 2, 1, 1, 1 }, 1];
            yield return [new[] { 2, 2, 2, 1, 1, 1, }, 3];
            yield return [new[] { 1, 2, 3, 3, 2, 1 }, 2];
            yield return [new[] { 1 }, 0];
        }
    }

    [Theory]
    [ClassData(typeof(Data))]
    public void Theory(IList<int> input, int output)
    {
        var result = s.MinimumOperations(input);
        Assert.Equal(output, result);
    }
}