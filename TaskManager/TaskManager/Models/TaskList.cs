namespace TaskManager.Models;


public class TaskList
{
    private readonly List<TaskItem> _tasks = [];
    private int _nextId = 1;

    public IReadOnlyList<TaskItem> Tasks => _tasks.AsReadOnly();

    public TaskItem Add(string title)
    {
        var task = new TaskItem
        {
            Id = _nextId++,
            Title = title,
            IsCompleted = false
        };
        _tasks.Add(task);
        return task;
    }

    public TaskItem? Remove(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            _tasks.Remove(task);
        }
        return task;
    }

    public void RestoreTask(TaskItem task)
    {
        _tasks.Add(task);
    }

    public TaskItem? GetById(int id)
    {
        return _tasks.FirstOrDefault(t => t.Id == id);
    }

    public bool MarkAsCompleted(int id)
    {
        var task = GetById(id);
        if (task != null)
        {
            task.IsCompleted = true;
            return true;
        }
        return false;
    }

    public bool MarkAsIncomplete(int id)
    {
        var task = GetById(id);
        if (task != null)
        {
            task.IsCompleted = false;
            return true;
        }
        return false;
    }

    public void PrintTasks()
    {
        if (_tasks.Count == 0)
        {
            Console.WriteLine("Null");
            return;
        }

        Console.WriteLine("\nToDO:");
        foreach (var task in _tasks.OrderBy(t => t.Id))
        {
            Console.WriteLine(task);
        }
        Console.WriteLine();
    }
}
