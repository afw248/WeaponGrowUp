namespace Command
{
    using UnityEngine;
    public interface ICommand<T>
    {
        public void Execute(T actor);
    }
}