using System.Globalization;

namespace ConsoleApp_Roman.Task1;

public class Calculator
{

    /// <summary>
    /// This method calculates expression with 2 operands.
    /// </summary>
    /// <returns>Returns result</returns>
    public string Calculate(string? expression)
    {
        if (string.IsNullOrEmpty(expression))
            return "";

        expression = expression.Replace(" ", "");

        // Найти позицию бинарного оператора
        // Бинарный — тот, что НЕ первый символ и НЕ идёт сразу после другого оператора
        var opIndex = -1;
        var op = '\0';

        for (var i = 1; i < expression.Length; i++)  // начинаем с 1, чтобы не взять унарный минус в начале
        {
            var c = expression[i];
            if (c == '+' || c == '-' || c == '*' || c == '/')
            {
                // Проверяем, что это бинарный оператор:
                // предыдущий символ — цифра
                if (char.IsDigit(expression[i - 1]))
                {
                    opIndex = i;
                    op = c;
                    break;
                }
            }
        }

        if (opIndex == -1)
            return "Expression operation is not found. Please check you expression";

        var left = expression.Substring(0, opIndex);
        var right = expression.Substring(opIndex + 1);

        if (!int.TryParse(left, out var digit1))
            return "Impossible convert the first operand to digit";

        if (!int.TryParse(right, out var digit2))
            return "Impossible convert the second operand to digit";

        switch (op)
        {
            case '+': return (digit1 + digit2).ToString();
            case '-': return (digit1 - digit2).ToString();
            case '*': return (digit1 * digit2).ToString();
            case '/':
                if (digit2 == 0)
                    return "Impossible to divide to 0";
                return ((double)digit1 / digit2).ToString(CultureInfo.InvariantCulture);
            default:
                return "Unknown expression operation";
        }
    }
}