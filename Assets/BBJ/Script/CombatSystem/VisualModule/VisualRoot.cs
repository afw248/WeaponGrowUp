namespace Visual
{
    using System.Collections.Generic;
    using UnityEngine;
    public class VisualRoot : MonoBehaviour, IVisualRoot
    {
        [field: SerializeField]
        public Transform ModuleSlot { get; private set; }
        public Transform VisualTransform => this.transform;

        protected List<IVisualModule> activeModules = new();

        public virtual void AttachModule(IVisualModule module)
        {
            module.Attach(this);
            activeModules.Add(module);
        }

        public void DetachAll()
        {
            foreach (var module in activeModules)
                module.Detach();

            activeModules.Clear();
        }
    }
}