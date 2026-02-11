namespace Fectory
{
    using UnityEngine;

    public abstract class FectorySO<T> : ScriptableObject
    {
        protected abstract T CreateInstance();
    }
}