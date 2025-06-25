namespace LeetCode.Problems;

public class _2766_Relocate_Marbles
{
    public class Solution
    {
        public IList<int> RelocateMarbles(int[] nums, int[] moveFrom, int[] moveTo)
        {
            var hs = nums.ToHashSet();
            for (int i = 0; i < moveFrom.Length; i++)
            {
                hs.Remove(moveFrom[i]);
                hs.Add(moveTo[i]);
            }
            return hs.AsEnumerable().OrderBy(h => h).ToList();
        }
    }

    private readonly Solution s = new();

    private class Data : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return [new[] { 1, 6, 7, 8 }, new[] { 1, 7, 2 }, new[] { 2, 9, 5 }, new[] { 5, 6, 8, 9 }];
            yield return [new[] { 1, 1, 3, 3 }, new[] { 1, 3 }, new[] { 2, 2 }, new[] { 2 }];
        }
    }

    [Theory]
    [ClassData(typeof(Data))]
    public void Theory(int[] nums, int[] moveFrom, int[] moveTo, int[] output)
    {
        var result = s.RelocateMarbles(nums, moveFrom, moveTo);
        Assert.Equal(output, result);
    }
}