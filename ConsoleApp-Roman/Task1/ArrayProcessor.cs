namespace ConsoleApp_Roman.Task1;

public class ArrayProcessor
{
    public string Process()
    {
        try
        {
            var arr = new int[10];
            var rnd = new Random();

            for (var i = 0; i < 10; i++)
            {
                arr[i] = rnd.Next(1, 100);
            }

            var min = arr.Min();
            var max = arr.Max();
            var avg = arr.Average();

            return $"{min} {max} {avg}";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}