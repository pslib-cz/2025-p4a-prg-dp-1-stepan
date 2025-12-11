using TaskManager.Models;

namespace TaskManager.Commands;

/// <summary>
/// Pøíkaz pro odstranìní úkolu
/// </summary>
public class RemoveTaskCommand : ICommand
{
    private readonly TaskList _taskList;
    private readonly int _taskId;
    private TaskItem? _removedTask;

    public string Description => $"Deleta task by ID: {_taskId}";

    public RemoveTaskCommand(TaskList taskList, int taskId)
    {
        _taskList = taskList;
        _taskId = taskId;
    }

    public void Execute()
    {
        _removedTask = _taskList.Remove(_taskId);
        if (_removedTask != null)
        {
            Console.WriteLine($"Task '{_removedTask.Title}' was deleted.");
        }
        else
        {
            Console.WriteLine($"Task w ID: {_taskId} does not exits");
        }
    }

    public void Undo()
    {
        if (_removedTask != null)
        {
            _taskList.RestoreTask(_removedTask);
            Console.WriteLine($"Task '{_removedTask.Title}' was readded");
        }
    }
}
