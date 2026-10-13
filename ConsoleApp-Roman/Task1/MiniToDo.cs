using System.Text;

namespace ConsoleApp_Roman.Task1;

public class MiniToDo
{
    private readonly List<string> _tasks = new List<string>();

    public void Process()
    {
        try
        {
            var isExited = false;

            while (!isExited)
            {
                ShowMenu();

                Console.WriteLine();
                Console.Write("Option: ");
                var option = Console.ReadLine();

                if (string.IsNullOrEmpty(option))
                    continue;

                switch (option)
                {
                    case "1":
                        AddTask();
                        break;

                    case "2":
                        ShowTasks();
                        break;

                    case "3":
                        RemoveByNumber();
                        break;

                    case "4":
                        isExited = true;
                        break;

                    default:
                        Console.WriteLine("Неизвестный вариант.");
                        continue;
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    private void ShowMenu()
    {
        Console.WriteLine("ToDo");
        Console.WriteLine("1. Add task");
        Console.WriteLine("2. Show all tasks");
        Console.WriteLine("3. Remove by number");
        Console.WriteLine("4. Exit");
    }

    private void AddTask()
    {
        Console.Write("Task: ");
        var taskName = Console.ReadLine();
        if (string.IsNullOrEmpty(taskName))
            return;

        _tasks.Add(taskName);
    }

    private void ShowTasks()
    {
        if (_tasks.Count == 0)
            Console.WriteLine("[EMPTY]");

        var sb = new StringBuilder();
        for (var i = 0; i < _tasks.Count; i++)
        {
            sb.AppendLine($"{i + 1}. {_tasks[i]}");
        }

        Console.WriteLine(sb.ToString());
    }

    private void RemoveByNumber()
    {
        Console.Write("Number: ");
        var indexStr = Console.ReadLine();

        if (int.TryParse(indexStr, out var index))
        {
            if (index > _tasks.Count)
                return;

            _tasks.RemoveAt(index - 1);
        }
    }
}