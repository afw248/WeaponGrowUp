namespace Visual
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    public interface IReadOnlyVisualRoot
    {
        public Transform ModuleSlot { get; }
        public Transform VisualTransform { get; }
        public Dictionary<Type,Component> Components { get;}
    }
}