namespace Command
{
    public class CommandManager
    {
        private readonly List<ICommand> _history = new();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _history.Add(command);
        }
    }
}
