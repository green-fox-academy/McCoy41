using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace _24_CountLetters
{
    public class Tests
    {
        [Fact]
        public void TestEmptyOutput()
        {
            Assert.Equal("", Program.ToString(new Dictionary<char, uint>()));
        }

        [Fact]
        public void TestOutput()
        {
            var input = new Dictionary<char, uint>();
            input.Add('A', 5);
            Assert.Equal(" A | 5\n", Program.ToString(input));
        }

        [Fact]
        public void TestEmptyInput()
        {
            Assert.Equal(new Dictionary<char, uint>(), Program.CountLetters(""));
        }

        [Fact]
        public void TestInput1()
        {
            var expected = new Dictionary<char, uint>();
            expected.Add('B', 1);
            expected.Add('E', 1);
            expected.Add('L', 1);
            expected.Add('K', 1);
            expected.Add('R', 1);
            Assert.Equal(expected, Program.CountLetters("Blerk"));
        }
        
        [Fact]
        public void TestInput2()
        {
            var expected = new Dictionary<char, uint>();
            expected.Add('A', 1);
            expected.Add('D', 1);
            expected.Add('E', 1);
            expected.Add('H', 2);
            expected.Add('I', 2);
            expected.Add('R', 2);
            expected.Add('T', 2);
            expected.Add('!', 3);
            Assert.Equal(expected, Program.CountLetters("Hit it harder!!!"));
        }

        [Fact]
        public void TestSort()
        {
            Assert.Equal("ABCD", Program.Sort("DACB"));
        }
    }
}
