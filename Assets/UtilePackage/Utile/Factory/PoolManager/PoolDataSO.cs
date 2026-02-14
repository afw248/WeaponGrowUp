
namespace Fectory
{
    using UnityEngine;
    using CustomEditor;
    [CreateAssetMenu(fileName = "PoolSO", menuName = "Pool/Item")]
    public class PoolItemSO : ScriptableObject
    {
        [ReadOnly] public string PoolName;
        [SerializeField] private GameObject _prefab;

        [field: SerializeField]
        public int Count { get; private set; }
        public IPoolable Prefab { get; private set; }

        private void OnValidate()
        {
            if (_prefab != null)
            {
                if (_prefab.TryGetComponent<IPoolable>(out var pool))
                {
                    this.PoolName = pool.ItemName;
                    this.Prefab = pool;
                }
                else
                {
                    Prefab = default;
                    Debug.LogWarning("can't find poolable instance");
                }
            }
        }
    }
}