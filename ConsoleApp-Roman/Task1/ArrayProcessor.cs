using System.Text;

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
                arr[i] = rnd.Next(1, 101);
            }

            var min = arr[0];
            var max = arr[0];

            var sum = 0;
            for (var i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min) min = arr[i];
                if (arr[i] > max) max = arr[i];

                sum += arr[i];
            }

            var avg = sum / arr.Length;

            var arrValues = new StringBuilder();
            foreach (var item in arr)
            {
                arrValues.Append($"{item} ");
            }

            var res = $"{arrValues}{Environment.NewLine}{min} {max} {avg}";

            return res;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}