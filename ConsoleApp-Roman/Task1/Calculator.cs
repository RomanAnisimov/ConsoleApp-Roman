namespace ConsoleApp_Roman.Task1;

public class Calculator
{
    public string Calculate()
    {
        try
        {
            Console.Write("Write expression (2 digits): ");
            var expression = Console.ReadLine();
            if (string.IsNullOrEmpty(expression))
                return "";

            expression = expression.Replace(" ", "");

            string[] operations = ["+", "-", "*", "/"];
            var expressionOperation = "";

            foreach (var operation in operations)
            {
                if (expression.Contains(operation))
                {
                    expressionOperation = operation;
                    break;
                }
            }

            var digitsStr = expression.Split(expressionOperation);
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

                    return (digit1 / digit2).ToString();

                default:
                    return "Unknown expression operation";
            }
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}