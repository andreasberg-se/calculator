using System;
using Xunit;

namespace Calculator.Test
{
    public class CalculationTests
    {
        [Fact]
        public void Addition_Test()
        {
            double num1 = 2;
            double num2 = 5;

            double expectedResult = 7;

            double result = Program.Add(num1, num2);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Subtraction_Test()
        {
            double num1 = 10;
            double num2 = 4;

            double expectedResult = 6;

            double result = Program.Subtract(num1, num2);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Multiplication_Test()
        {
            double num1 = 5;
            double num2 = 8;

            double expectedResult = 40;

            double result = Program.Multiply(num1, num2);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(20, 4, 5)]
        [InlineData(10, 3, 3.333)]
        [InlineData(100, 25, 4)]
        public void Division_Test(double num1, double num2, double expectedResult)
        {
            double result = Program.Divide(num1, num2);

            Assert.Equal(expectedResult, result, 3);
        }

        [Fact]
        public void Division_By_Zero_Test()
        {
            double num1 = 10;
            double num2 = 0;

            var expectedResult = Assert.Throws<DivideByZeroException>(() => Program.Divide(num1, num2));

            Assert.Equal(Program.DivideByZeroMessage, expectedResult.Message);
        }
    }

    public class ArrayCalculationTests
    {
        [Fact]
        public void Addition_Array_Test()
        {
            double[] numbers = {10, 5, 7, 10, 22, 30.5};

            double expectedResult = 84.5;

            double result = Program.Add(numbers);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(new double[] {100, 50, 25, 12.5}, 12.5)]
        [InlineData(new double[] {120, 20, 10, 25, 5}, 60)]
        public void Subtraction_Array_Test(double[] numbers, double expectedResult)
        {
            double result = Program.Subtract(numbers);

            Assert.Equal(expectedResult, result);
        }
    }
}
