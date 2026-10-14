using System.Text;

namespace ConsoleApp_Roman.Task1;

public class MultiplicationProcessor
{
    public string Process()
    {
        Console.Write("Digit: ");
        var digitStr = Console.ReadLine();

        if (string.IsNullOrEmpty(digitStr))
            return "Press a digit for multiplication";

        if (!int.TryParse(digitStr, out int digit))
        {
            return "Impossible to convert to digit";
        }

        var sb = new StringBuilder();
        for (var i = 1; i <= 10; i++)
        {
            sb.Append($"{digit * i} ");
        }

        return sb.ToString();
    }
}