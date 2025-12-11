using TaskManager.Commands;
using TaskManager.Models;

namespace TaskManager.UI;

public class ConsoleUI
{
    private readonly TaskList _taskList;
    private readonly CommandInvoker _invoker;
    private bool _running = true;

    public ConsoleUI()
    {
        _taskList = new TaskList();
        _invoker = new CommandInvoker();
    }

    public void Run()
    {
        Console.WriteLine("ToDO:");
        Console.WriteLine("Commands: add, remove, complete, list, undo, help \n");

        while (_running)
        {
            Console.Write("> ");
            var input = Console.ReadLine()?.Trim();
            
            if (string.IsNullOrEmpty(input))
                continue;

            ProcessInput(input);
        }
    }

    private void ProcessInput(string input)
    {
        var parts = input.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
        var command = parts[0].ToLower();
        var argument = parts.Length > 1 ? parts[1] : string.Empty;

        switch (command)
        {
            case "add":
                HandleAdd(argument);
                break;
            case "remove":
                HandleRemove(argument);
                break;
            case "complete":
                HandleComplete(argument);
                break;
            case "list":
                _taskList.PrintTasks();
                break;
            case "undo":
                _invoker.Undo();
                break;
            case "help":
                PrintHelp();
                break;
            default:
                Console.WriteLine($"Missclick?");
                break;
        }
    }

    private void HandleAdd(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("Write: add <task name>");
            return;
        }

        var command = new AddTaskCommand(_taskList, title);
        _invoker.ExecuteCommand(command);
    }

    private void HandleRemove(string argument)
    {
        if (!int.TryParse(argument, out int id))
        {
            Console.WriteLine("USe: remove <task id>");
            return;
        }

        var command = new RemoveTaskCommand(_taskList, id);
        _invoker.ExecuteCommand(command);
    }

    private void HandleComplete(string argument)
    {
        if (!int.TryParse(argument, out int id))
        {
            Console.WriteLine("USe: complete <task id>");
            return;
        }

        var command = new CompleteTaskCommand(_taskList, id);
        _invoker.ExecuteCommand(command);
    }

    private static void PrintHelp()
    {
        Console.WriteLine("\n=== Nápovìda ===");
        Console.WriteLine("add <name>     - add task");
        Console.WriteLine("remove <id>    - remove task id");
        Console.WriteLine("complete <id>  - mark task as complete");
        Console.WriteLine("list           - list all tasks");
        Console.WriteLine("undo           - revert last change");
        Console.WriteLine("help           - print all comands");
    }
}
