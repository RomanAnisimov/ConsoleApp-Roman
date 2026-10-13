namespace ConsoleApp_Roman.Task1;

public class EvenOddProcessor
{
    public string Process()
    {
        try
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
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}