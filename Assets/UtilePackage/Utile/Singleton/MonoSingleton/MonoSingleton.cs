namespace Singleton
{
    using UnityEngine;

    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        static private MonoSingleton<T> _instance;
        static public MonoSingleton<T> Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameObject().AddComponent<T>();
                return _instance;
            }
        }
        protected virtual void Awake()
        {
            if (_instance == null)
                _instance = this;
            else if (_instance != this)
                Destroy(this);
        }
        protected virtual void OnDestroy()
        {
            if (_instance == this)
                _instance = null;
        }
    }
}