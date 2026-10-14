using System.Text;
using System.Text.Json;

namespace ConsoleApp_Roman.Task1;

public class MiniToDo
{
    private readonly string _taskFilePath;
    private List<string> _tasks = [];

    public MiniToDo()
    {
        _taskFilePath = Path.Combine(AppContext.BaseDirectory, "Tasks.json");
    }

    /// <summary>
    /// This async method read tasks from json file.
    /// </summary>
    /// <returns></returns>
    public async Task InitializeAsync()
    {
        try
        {
            var json = await File.ReadAllTextAsync(_taskFilePath);
            _tasks = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
        }
        catch (JsonException)
        {
            Console.WriteLine("The json file was corrupted. Empty list tasks will be used.");
            _tasks = new List<string>();
        }
        catch (IOException ex)
        {
            Console.WriteLine("Failed to read json file with tasks. Empty list tasks will be used.");
            Console.WriteLine(ex.Message);
            _tasks = new List<string>();
        }
    }

    /// <summary>
    /// This async method for working with miniToDo
    /// </summary>
    /// <returns></returns>
    public async Task ProcessAsync()
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
                    await SaveTasksToFile();
                    break;

                case "2":
                    ShowTasks();
                    break;

                case "3":
                    RemoveByNumber();
                    await SaveTasksToFile();
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
        {
            Console.WriteLine("[EMPTY]");
            return;
        }

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
            if (index > _tasks.Count || index < 1)
                return;

            _tasks.RemoveAt(index - 1);
        }
    }

    private async Task SaveTasksToFile()
    {
        try
        {
            // Read tasks from json file
            var json = JsonSerializer.Serialize(_tasks);
            await File.WriteAllTextAsync(_taskFilePath, json);
        }
        catch (IOException ex)
        {
            Console.WriteLine("Failed to write tasks to json file. The changes will be saved. ");
            Console.WriteLine(ex.ToString());
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine("Need more permissions for writing ti json file. The changes will be saved.");
            Console.WriteLine(ex.ToString());
        }
    }
}