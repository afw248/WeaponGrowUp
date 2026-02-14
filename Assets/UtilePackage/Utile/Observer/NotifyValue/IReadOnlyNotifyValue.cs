using System;
namespace NotifyValue
{
    public interface IReadOnlyNotifyValue<T>
    {
        public T Value { get; }

        public event Action<T, T> OnValueChanged;
    }
}