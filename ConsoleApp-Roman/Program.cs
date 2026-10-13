using System.Text;
using ConsoleApp_Roman.Task1;

Console.OutputEncoding = Encoding.UTF8;

while (true)
{
    Console.WriteLine("Menu");
    Console.WriteLine("1. Calculator");
    Console.WriteLine("2. Чётное/нечётное");
    Console.WriteLine("3. Таблица умножения");
    Console.WriteLine("4. Сумма чисел от 1 до N");
    Console.WriteLine("5. Работа с массивом");
    Console.WriteLine("6. Список задач (мини-ToDo)");

    Console.WriteLine();
    Console.Write("Выберите вариант: ");
    var option = Console.ReadLine();

    if (string.IsNullOrEmpty(option))
        continue;

    switch (option)
    {
        case "1":
            var answer = new Calculator().Calculate();
            Console.WriteLine($"> {answer}");
            break;

        case "2":
            break;

        case "3":
            break;

        case "4":
            break;

        case "5":
            break;

        case "6":
            break;

        default:
            Console.WriteLine("Неизвестный вариант.");
            continue;
    }
}