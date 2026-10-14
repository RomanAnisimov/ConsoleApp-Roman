namespace ConsoleApp_Roman.Task1;

public class SumProcessor
{
    public string Process()
    {
        Console.Write("Digit: ");
        var digitStr = Console.ReadLine();

        if (string.IsNullOrEmpty(digitStr))
            return "Press a digit for sum";

        if (!long.TryParse(digitStr, out long digit))
        {
            return "Impossible to convert to digit";
        }

        var sumByLoop = SumByLoop(digit);
        var sumByFormula = SumByFormula(digit);

        return $"{sumByLoop} == {sumByFormula}";
    }

    private long SumByLoop(long digit)
    {
        var sum = 0L;
        for (long i = 1; i <= digit; i++)
        {
            sum += i;
        }

        return sum;
    }

    private long SumByFormula(long digit)
    {
        checked
        {
            var sum = digit % 2 == 0
                ? digit / 2 * (digit + 1)
                : digit * ((digit + 1) / 2);
            return sum;
        }
    }
}