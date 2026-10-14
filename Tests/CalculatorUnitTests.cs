using ConsoleApp_Roman.Task1;

namespace Tests
{
    public class CalculatorUnitTests
    {
        private readonly Calculator _calculator = new Calculator();

        [Theory]
        [InlineData("2+2", "4")]
        [InlineData("2-2", "0")]
        [InlineData("2*3", "6")]
        [InlineData("20/2", "10")]
        [InlineData("5/2", "2.5")]
        [InlineData("0/5", "0")]
        [InlineData("-2-2", "-4")]
        [InlineData("2*-3", "-6")]
        [InlineData("-5/2", "-2.5")]
        [InlineData("-5", "Expression operation is not found. Please check you expression")]
        [InlineData("5", "Expression operation is not found. Please check you expression")]
        [InlineData("2+3+4", "Impossible convert the second operand to digit")]
        [InlineData("", "")]
        [InlineData("2+", "Impossible convert the second operand to digit")]
        [InlineData("2--3", "5")]
        [InlineData("2-+3", "-1")]
        public void Calculate_ValidExpression_ReturnsExceptedResult(string expression, string expected)
        {
            var res = _calculator.Calculate(expression);
            Assert.Equal(expected, res);
        }

        [Fact]
        public void Calculate_DivisionToZero_ReturnsErrorMessage()
        {
            var expression = "5/0";
            var res = _calculator.Calculate(expression);
            Assert.Equal("Impossible to divide to 0", res);
        }

        [Fact]
        public void Calculate_FirstOperandNotDigit_ReturnsOperationNotFound()
        {
            var expression = "a+5";
            var res = _calculator.Calculate(expression);
            Assert.Equal("Expression operation is not found. Please check you expression", res);
        }

        [Fact]
        public void Calculate_IncorrectTheSecondValue_ReturnsErrorMessage()
        {
            var expression = "5+a";
            var res = _calculator.Calculate(expression);
            Assert.Equal("Impossible convert the second operand to digit", res);
        }
    }
}