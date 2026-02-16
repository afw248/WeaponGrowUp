namespace Visual
{
    using Unity.VisualScripting;
    using UnityEngine;

    public abstract class VisulModule : ScriptableObject, IVisualModule
    {
        [SerializeField] public VisualActionEnum Action { get; private set; }
        public abstract void Attach(IReadOnlyVisualRoot root);
        public virtual void Update(){}
        public abstract void Detach();

        // 타입마다 풀링해야해서 T사용
        protected T GetOrAddComponent<T>(IReadOnlyVisualRoot root) where T : Component
        {
            var components = root.Components;
            if (false == components.TryGetValue(typeof(T), out var animator))
            {
                animator = root.ModuleSlot.GetOrAddComponent<T>();
                components.Add(typeof(T), animator);
            }
            return animator as T;
        }
        protected void DestroyComponent<T>(T component) where T : Component
        {
            GameObject.Destroy(component);
        }
    }
}