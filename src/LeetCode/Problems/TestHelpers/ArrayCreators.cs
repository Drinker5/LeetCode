using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LeetCode.Problems
{
    public static class ArrayCreators
    {
        /// <summary></summary>
        /// <param name="input">[[0,0],[2,0],[1,1],[2,1],[2,2]]</param>
        public static T[][] Make2DArray<T>(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException();

            var split = input.Split('[');
            var rows = split.Length - 2;
            T[][] res = new T[rows][];
            for (int i = 0; i < rows; i++)
            {
                var split2 = split[i + 2].Split(']').First().Split(',');
                var cols = split2.Where(s => !string.IsNullOrEmpty(s)).Count();
                res[i] = new T[cols];
                for (int j = 0; j < cols; j++)
                    res[i][j] = Parse<T>(split2[j]);
            }

            return res;
        }

        private static T Parse<T>(string v) => (T)Convert.ChangeType(v, typeof(T));
    }

    public class ArrayCreatorsTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void when_error_input_then_throws(string input)
        {
            Assert.Throws<ArgumentException>(() => ArrayCreators.Make2DArray<int>(input));
        }

        [Fact]
        public void when_empty_array()
        {
            var result = ArrayCreators.Make2DArray<int>("[]");

            Assert.Empty(result);
        }

        [Fact]
        public void when_single_element()
        {
            var result = ArrayCreators.Make2DArray<int>("[[]]");

            Assert.Single(result);
        }

        [Fact]
        public void when_single_with_value_element()
        {
            var result = ArrayCreators.Make2DArray<int>("[[1]]");

            var arr = Assert.Single(result);
            var value = Assert.Single(arr);
            Assert.Equal(1, value);
        }

        [Fact]
        public void when_two_with_single_element()
        {
            var result = ArrayCreators.Make2DArray<int>("[[1],[2]]");

            Assert.Equal(2, result.Length);
            Assert.Equal(1, Assert.Single(result[0]));
            Assert.Equal(2, Assert.Single(result[1]));
        }

        [Fact]
        public void when_multiple_elements()
        {
            var result = ArrayCreators.Make2DArray<char>("[[a,b,c]]");

            var arr = Assert.Single(result);
            Assert.Collection(arr,
                i => Assert.Equal('a', i),
                i => Assert.Equal('b', i),
                i => Assert.Equal('c', i)
                );
        }

        [Fact]
        public void when_multiple_string_elements()
        {
            var result = ArrayCreators.Make2DArray<string>("[[foo,bar,quux]]");

            var arr = Assert.Single(result);
            Assert.Collection(arr,
                i => Assert.Equal("foo", i),
                i => Assert.Equal("bar", i),
                i => Assert.Equal("quux", i)
                );
        }

        [Fact]
        public void when_multiple_arrays()
        {
            var result = ArrayCreators.Make2DArray<int>("[[],[],[]]");

            Assert.Equal(3, result.Length);
        }

        [Fact]
        public void when_two_arrays_different_sizes()
        {
            var result = ArrayCreators.Make2DArray<long>("[[1],[2,3]]");

            Assert.Equal(2, result.Length);

            Assert.Collection(result[0],
                i => Assert.Equal(1, i));
            Assert.Collection(result[1],
                i => Assert.Equal(2, i),
                i => Assert.Equal(3, i));
        }
    }
}
