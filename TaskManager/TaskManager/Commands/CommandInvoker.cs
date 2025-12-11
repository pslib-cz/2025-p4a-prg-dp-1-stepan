namespace TaskManager.Commands;


public class CommandInvoker
{
    private readonly Stack<ICommand> _commandHistory = new();


    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _commandHistory.Push(command);
    }

    public bool Undo()
    {
        if (_commandHistory.Count == 0)
        {
            Console.WriteLine("Huh?!");
            return false;
        }

        var command = _commandHistory.Pop();
        command.Undo();
        return true;
    }

    public int HistoryCount => _commandHistory.Count;
}
