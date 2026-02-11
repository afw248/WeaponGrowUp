namespace Command
{
    public interface ICommand<T>
    {
        public void Execute(T actor);
    }
    public interface ICommand
    {
        public void Execute();
    }
}