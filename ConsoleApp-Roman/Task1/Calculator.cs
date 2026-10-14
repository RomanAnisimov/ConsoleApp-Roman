using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace ConsoleApp_Roman.Task1;

public class Calculator
{
    private readonly string[] _operations = ["+", "-", "*", "/"];

    /// <summary>
    /// This methods calculates expression with 2 operands.
    /// </summary>
    /// <returns>Returns result</returns>
    public string Calculate()
    {
        Console.Write("Write expression (2 digits): ");
        var expression = Console.ReadLine();
        if (string.IsNullOrEmpty(expression))
            return "";

        expression = expression.Replace(" ", ""); //Remove all spaces
        var expressionOperation = "";

        foreach (var operation in _operations) // Search expression operation (+ or - or * or /)
        {
            if (expression.Contains(operation))
            {
                expressionOperation = operation;
                break;
            }
        }

        if (string.IsNullOrEmpty(expressionOperation)) // Expression operation did not found
        {
            return "Expression operation is not found. Please check you expression";
        }

        var digitsStr = expression.Split(expressionOperation);

        if (digitsStr.Length != 2) // Work only 2 expression operand! I.e., 2+2+2 is not correct expression, since here 3 operands
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

    public string CalculateRegex()
    {
        Console.Write("Write expression: ");
        var expression = Console.ReadLine();
        if (string.IsNullOrEmpty(expression))
            return "";

        var matches = Regex.Matches(expression, @"(?<=[*/+\-]|^)[+-]?\d+|[*/+\-]")
            .Select(x => x.Value)
            .ToArray();

        double res = 0.0;
        var operation = "";
        for (var i = 0; i < matches.Length; i++)
        {
            if (double.TryParse(matches[i], out double d))
            {
                if (!string.IsNullOrEmpty(operation))
                {
                    var validationRes = ValidateOperation(operation, d);
                    if (! string.IsNullOrEmpty(validationRes))
                    {
                        return validationRes;
                    }
                    res = CalculateInternal(res, operation, d);
                }
                else if (i == 0) // first value. Just to keep it.
                {
                    res = d;
                }
            }
            else if (_operations.Contains(matches[i]))
            {
                operation = matches[i];
            }
        }

        return res.ToString(CultureInfo.InvariantCulture);
    }

    private double CalculateInternal(double curRes, string operation, double digit)
    {
        switch (operation)
        {
            case "+":
                curRes += digit;
                break;

            case "-":
                curRes -= digit;
                break;

            case "*":
                curRes *= digit;
                break;

            case "/":
                curRes /= digit;
                break;

            default:
                return curRes;
        }

        return curRes;
    }

    private string ValidateOperation(string operation, double digit)
    {
        if (operation == "/" && digit == 0)
            return "Impossible to divide to 0";

        return string.Empty;
    }
}