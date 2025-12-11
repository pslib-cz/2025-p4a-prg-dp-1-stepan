using TaskManager.Models;

namespace TaskManager.Commands;

public class AddTaskCommand : ICommand
{
    private readonly TaskList _taskList;
    private readonly string _title;
    private TaskItem? _addedTask;

    public string Description => $"Add task: {_title}";

    public AddTaskCommand(TaskList taskList, string title)
    {
        _taskList = taskList;
        _title = title;
    }

    public void Execute()
    {
        _addedTask = _taskList.Add(_title);
        Console.WriteLine($"Task '{_title}' was added w ID: {_addedTask.Id}.");
    }

    public void Undo()
    {
        if (_addedTask != null)
        {
            _taskList.Remove(_addedTask.Id);
            Console.WriteLine($"Task '{_title}' was deleted.");
        }
    }
}
