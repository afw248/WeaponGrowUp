namespace Visual
{
    using UnityEngine;

    public interface IReadOnlyVisualRoot
    {
        public Transform ModuleSlot { get; }

        public Transform VisualTransform { get; }
    }
}