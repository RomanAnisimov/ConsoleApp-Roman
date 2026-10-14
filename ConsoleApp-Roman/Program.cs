using System.Text;
using ConsoleApp_Roman.Task1;

Console.OutputEncoding = Encoding.UTF8;
MiniToDo miniToDo = null;

while (true)
{
    Console.WriteLine("Menu");
    Console.WriteLine("1. Calculator");
    Console.WriteLine("2. Even/odd");
    Console.WriteLine("3. Multiplication");
    Console.WriteLine("4. Digits sum from 1 to N");
    Console.WriteLine("5. Work with array");
    Console.WriteLine("6. Mini-ToDo");

    Console.WriteLine();
    Console.Write("Option: ");
    var option = Console.ReadLine();

    if (string.IsNullOrEmpty(option))
        continue;

    var answer = "";

    switch (option)
    {
        case "1":
            answer = new Calculator().CalculateRegex();
            break;

        case "2":
            answer = new EvenOddProcessor().Process();
            break;

        case "3":
            answer = new MultiplicationProcessor().Process();
            break;

        case "4":
            answer = new SumProcessor().Process();
            break;

        case "5":
            answer = new ArrayProcessor().Process();
            break;

        case "6":
            if (miniToDo == null)
            {
                miniToDo = new MiniToDo();
                await miniToDo.InitializeAsync();
            }

            await miniToDo.ProcessAsync();
            break;

        default:
            Console.WriteLine("Неизвестный вариант.");
            continue;
    }

    Console.WriteLine($"> {answer}");
}