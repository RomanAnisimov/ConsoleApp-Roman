using System.Globalization;

namespace ConsoleApp_Roman.Task1;

public class Calculator
{
    private readonly string[] _operations = ["+", "-", "*", "/"];

    public string Calculate()
    {
        Console.Write("Write expression (2 digits): ");
        var expression = Console.ReadLine();
        if (string.IsNullOrEmpty(expression))
            return "";

        expression = expression.Replace(" ", "");
        var expressionOperation = "";

        foreach (var operation in _operations)
        {
            if (expression.Contains(operation))
            {
                expressionOperation = operation;
                break;
            }
        }

        if (string.IsNullOrEmpty(expressionOperation))
        {
            return "Expression operation is not found. Please check you expression";
        }

        var digitsStr = expression.Split(expressionOperation);

        if (digitsStr.Length != 2)
        {
            return "The expression should contain 2 operands";
        }

        if (!int.TryParse(digitsStr[0], out var digit1))
            return "Impossible convert the first operand to digit";

        if (!int.TryParse(digitsStr[1], out var digit2))
            return "Impossible convert the second operand to digit";

        switch (expressionOperation)
        {
            case "+":
                return (digit1 + digit2).ToString();

            case "-":
                return (digit1 - digit2).ToString();

            case "*":
                return (digit1 * digit2).ToString();

            case "/":
                if (digit2 == 0)
                    return "Impossible to divide to 0";

                return ((double)digit1 / digit2).ToString(CultureInfo.InvariantCulture);

            default:
                return "Unknown expression operation";
        }
    }
}