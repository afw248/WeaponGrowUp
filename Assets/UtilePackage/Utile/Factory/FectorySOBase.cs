namespace Fectory
{
    using UnityEngine;

    public abstract class FectorySOBase<T> : ScriptableObject
    {
        protected abstract T CreateInstance();
    }
}