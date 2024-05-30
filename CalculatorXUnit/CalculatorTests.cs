using Labb6XUnit;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Moq;
using Xunit.Abstractions;
using Xunit;
using System;
using System.IO;

namespace CalculatorXUnit
{
    public class CalculatorTests
    {

        [Fact]
        public void Addtions_Input_CorrectResult()
        {
            // Arrange
            Calculator calculator = new Calculator();
            double a = 10;
            double b = 15;
            double expected = 25;

            // Act
            double result = calculator.Add(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Subtraction_Input_CorrectResult()
        {
            //Arrange
            Calculator calculator = new Calculator();
            double a = 10;
            double b = 5;

            double expected = 5;
            //Act
            double result = calculator.Subtract(a, b);
            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Multiplication_Input_CorrectResult()
        {
            //Arrange
            Calculator calculator = new Calculator();
            double a = 10.5;
            double b = 3;
            double expected = 31.5;
            //Act
            double result = calculator.Multiply(a, b);
            //Assert
            Assert.Equal(expected, result);

        }
        [Theory]
        [InlineData("Division", 10, 5, 2)]
        [InlineData("Division", 10, 4, 2)]
        [InlineData("Division", 10, 5, 6)]
        [InlineData("Multiplication", 10, 5, 50)]
        [InlineData("Multiplication", 10, 2, 20)]
        
        public void PerformOperation_ValidInput_ReturnsCorrectResult(string operationName, double a, double b, double expectedResult)
        {
            // Arrange
            Calculator calculator = new Calculator();

            // Act
            double actualResult = PerformOperation(operationName, a, b, calculator);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        private double PerformOperation(string operationName, double a, double b, Calculator calculator)
        {
            switch (operationName)
            {
                case "Multiplication":
                    return calculator.Multiply(a, b);
                case "Division":
                    return calculator.Divide(a, b);
                default:
                    throw new ArgumentException("Invalid operation name");
            }
        }
    }
}
