namespace NotifyValue
{
    using System;
    using UnityEngine;

    [Serializable]
    public class NotifyValue<T> : IReadOnlyNotifyValue<T>
    {
        [SerializeField] private T _value;
        public event Action<T, T> OnValueChanged;

        public T Value
        {
            get => _value;
            set
            {
                T before = _value;
                _value = value;
                if ((before == null && _value != null) || before.Equals(_value) == false)
                    OnValueChanged?.Invoke(before, _value);
            }
        }

        public NotifyValue()
        {
            _value = default(T);
        }
        public NotifyValue(T value)
        {
            _value = value;
        }
    }
}