using System.Text;

namespace ConsoleApp_Roman.Task1;

public class MultiplicationProcessor
{
    /// <summary>
    /// This method calculates table of multiplication
    /// </summary>
    /// <returns>Returns table of multiplication</returns>
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
            sb.AppendLine($"{digit} * {i} = {digit * i}");
        }

        return sb.ToString();
    }
}