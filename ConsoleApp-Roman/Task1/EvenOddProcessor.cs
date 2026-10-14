namespace ConsoleApp_Roman.Task1;

public class EvenOddProcessor
{
    /// <summary>
    /// This method checks that the value is even or odd.
    /// </summary>
    /// <returns>Returns result. If the value is even then "Even". Otherwise, "Odd".</returns>
    public string Process()
    {
        Console.Write("Digit: ");
        var digitStr = Console.ReadLine();

        if (string.IsNullOrEmpty(digitStr))
            return "Press a digit for analyze";

        if (!int.TryParse(digitStr, out int digit))
        {
            return "Impossible to convert to digit";
        }

        return digit % 2 == 0 ? "Even" : "Odd";
    }
}