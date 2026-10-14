using System.Text;

namespace ConsoleApp_Roman.Task1;

public class ArrayProcessor
{
    private const int ArrSize = 10;
    private const int RndMin = 1;
    private const int RndMax = 100;

    /// <summary>
    /// This method generates random array and search min, max and avg values.
    /// </summary>
    /// <returns>Returns generated array and min, max and avg values.</returns>
    public string Process()
    {
        var arr = new int[ArrSize];
        var rnd = new Random();

        for (var i = 0; i < ArrSize; i++)
        {
            arr[i] = rnd.Next(RndMin, RndMax + 1);
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

        var avg = (double)sum / arr.Length;

        var arrValues = new StringBuilder();
        foreach (var item in arr)
        {
            arrValues.Append($"{item} ");
        }

        var res = $"Array: {arrValues}" +
                  $"{Environment.NewLine}" +
                  $"Min: {min} | Max: {max} | Avg: {avg}";

        return res;
    }
}