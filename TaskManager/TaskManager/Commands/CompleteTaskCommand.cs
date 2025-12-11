using TaskManager.Models;

namespace TaskManager.Commands;


public class CompleteTaskCommand : ICommand
{
    private readonly TaskList _taskList;
    private readonly int _taskId;
    private bool _wasCompleted;
    private bool _taskFound;

    public string Description => $"Mark task w ID: {_taskId} as done";

    public CompleteTaskCommand(TaskList taskList, int taskId)
    {
        _taskList = taskList;
        _taskId = taskId;
    }

    public void Execute()
    {
        var task = _taskList.GetById(_taskId);
        if (task != null)
        {
            _wasCompleted = task.IsCompleted;
            _taskFound = true;
            _taskList.MarkAsCompleted(_taskId);
            Console.WriteLine($"Task '{task.Title}' completed");
        }
        else
        {
            _taskFound = false;
            Console.WriteLine($"Task w ID {_taskId} does not exit");
        }
    }

    public void Undo()
    {
        if (_taskFound && !_wasCompleted)
        {
            _taskList.MarkAsIncomplete(_taskId);
            var task = _taskList.GetById(_taskId);
            Console.WriteLine($"Done");
        }
    }
}
