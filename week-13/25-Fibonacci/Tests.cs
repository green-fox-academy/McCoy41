using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace _25_Fibonacci
{
    public class Tests
    {
        //Fibonacci(n) = Fibonacci(n-1) + Fibonacci(n-2)
        //Assert.Equal doesn't work for uint...
        [Fact]
        public void FibonacciTest0()
        {
            Assert.True(Program.Fibonacci(0) == 0);
        }

        [Fact]
        public void FibonacciTest1()
        {
            Assert.True(Program.Fibonacci(1) == 1);
        }

        [Theory]
        [InlineData(3, 2)]
        [InlineData(8, 21)]
        public void FibonacciTestSmall(uint n, uint expected)
        {
            Assert.True(Program.Fibonacci(n) == expected);
        }

        [Theory]
        [InlineData(20)]
        [InlineData(30)]
        [InlineData(35)]
        public void FibonacciTestLarge(uint n)
        {
            Assert.True(Program.Fibonacci(n) == (Program.Fibonacci(n-1) + Program.Fibonacci(n-2)));
        }

        [Theory]
        [InlineData(3)]
        [InlineData(8)]
        [InlineData(23)]
        public void SequenceTest(uint length) // length + "0"
        {
            var test = new List<uint>();
            Program.Sequence(length, ref test);
            Assert.True(length + 1 == test.Count);
        }
    }
}
