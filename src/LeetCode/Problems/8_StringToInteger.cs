using System;
using System.Collections.Generic;
using Xunit;

namespace LeetCode.Problems
{
    public class _8_StringToInteger
    {
        private readonly Solution solution;

        public _8_StringToInteger()
        {
            solution = new Solution();
        }
        
        public class Solution
        {
            public int MyAtoi(string s)
            {
                int i = 0;

                while (i < s.Length && s[i] == ' ')
                    i++;
                if (i >= s.Length)
                    return 0;

                var sign = 1;
                if (s[i] == '+')
                {
                    i++;
                }
                else if (s[i] == '-')
                {
                    sign = -1;
                    i++;
                }

                if (i >= s.Length)
                    return 0;
                
                long par = 0;
                while (i < s.Length && Char.IsDigit(s[i]))
                {
                    var digit = Int32.Parse(s[i].ToString());
                    par = par * 10 + sign * digit;
                    if (par > Int32.MaxValue)
                        return Int32.MaxValue;
                    if (par < Int32.MinValue)
                        return Int32.MinValue;
                    i++;
                }

                return (int)par;
            }
        }
        
        [Theory]
        [InlineData("42", 42)]
        [InlineData("   -042", -42)]
        [InlineData("1337c0d3", 1337)]
        [InlineData("0-1", 0)]
        [InlineData("words and 987", 0)]
        [InlineData("-91283472332", -2147483648)]
        [InlineData("10000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000522545459", 2147483647)]
        [InlineData("  0000000000012345678", 12345678)]
        public void Solver(string s, int num)
        {
            var result = solution.MyAtoi(s);
            Assert.Equal(num, result);
        }
    }
}