namespace Cost
{
    using NotifyValue;
    using UnityEngine;
    using System;
    using Icon;

    [CreateAssetMenu(fileName = "Cost", menuName = "SO/Cost/Type")]
    public class CostSO : ScriptableObject
    {
        [field: SerializeField] public TextIconDataSO TextIcon { get; private set; }
        [field: SerializeField] public string Name { get; private set; }

        [SerializeField]private NotifyValue<int> _cost = new NotifyValue<int>(0);

        public int Value
        {
            get => _cost.Value;
            set
            {
                _cost.Value = Math.Clamp(value, 0, int.MaxValue);
            }

        }
        public event Action<int, int> NotifyEvent
        {
            add => _cost.OnValueChanged += value;
            remove => _cost.OnValueChanged -= value;
        }

        private void OnValidate()
        {
            if (Name == null || Name == "")
            {
                string name = null;
                if (TextIcon != null)
                    name = TextIcon.ID;
                Name = name;
            }
            name = Name;

        }

        public void Initialize(int value)
        {
            /*cost = new NotifyValue<int>(value);*/
           Value = value;
        }
        public bool ChackUseable(int value) => _cost.Value >= value;
        public bool TryUseable(int value)
        {
            bool canUseable = ChackUseable(value);

            if (canUseable)
                Value -= value;
            else
            {
                Debug.Log("금액 부족");
            }

                return canUseable;
        }
        public static implicit operator int(CostSO cost) => cost.Value;
    }
}