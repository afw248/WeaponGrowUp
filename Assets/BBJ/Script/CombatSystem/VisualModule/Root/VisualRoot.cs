namespace Visual
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    public class VisualRoot : MonoBehaviour, IVisualRoot
    {
        [field: SerializeField]
        public Transform ModuleSlot { get; private set; }
        public Transform VisualTransform => this.transform;

        private Dictionary<VisualActionEnum, List<IVisualModule>> activeModules;
        public Dictionary<Type, Component> Components { get; } = new();

        public void AttachModule(VisualActionEnum action, IVisualModule module)
        {
            module.Attach(this);
            if (false == activeModules.TryGetValue(action, out var modulelist))
            {
                modulelist = new List<IVisualModule>();
                activeModules.Add(action, modulelist);
            }
            modulelist.Add(module);
        }

        public void NotifyModule(VisualActionEnum action)
        {
            if (false == activeModules.TryGetValue(action, out var modulelist))
            {
                modulelist = new List<IVisualModule>();
                activeModules.Add(action, modulelist);
            }
            foreach (var module in modulelist)
                    module.Update();
        }
        public void DetachAll()
        {
            foreach (var modulelist in activeModules.Values)
                foreach (var module in modulelist)
                    module.Detach();
            activeModules.Clear();
            Components.Clear();
        }
    }
}