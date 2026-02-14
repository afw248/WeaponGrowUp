namespace Fectory
{
    using System.Collections.Generic;
    using UnityEngine;

    public class PoolManager : MonoBehaviour
    {
        [SerializeField] private PoolListSO itemList;
        private Dictionary<string, GameObjectPool> _pools = new();
        public static PoolManager Instance { get; private set; }
        private void Awake()
        {
            Init();

            foreach (var item in itemList.PoolList)
                CreatePool(item.Prefab, item.Count);
        }

        private void Init()
        {
            if (Instance == null)
                Instance = this;
            else if (Instance != this)
                Destroy(gameObject);
        }

        private void CreatePool(IPoolable prefab, int count)
        {
            Transform parent = CreateEmptyObject(prefab.ItemName + "Pool", this.transform);

            GameObjectPool pool = new GameObjectPool(prefab, parent, count);

            if (_pools.TryAdd(prefab.ItemName, pool) == false)
                Debug.LogAssertion(prefab.ItemName + " is a name that already exists.");
        }

        private Transform CreateEmptyObject(string name, Transform parent)
        {
            var empty = new GameObject(name);
            empty.transform.SetParent(parent);
            return empty.transform;
        }

        public IPoolable Pop(string itemName)
        {
            if (_pools.TryGetValue(itemName, out var item))
                return item.Pop();
            else
                Debug.LogError(itemName + " : There is no pool");
            return default;
        }
        public void Push(IPoolable pushItem)
        {
            if (_pools.TryGetValue(pushItem.ItemName, out var item))
                item.Push(pushItem);
            else
                Debug.LogError(pushItem.ItemName + " : There is no pool");
        }
        private void OnDestroy()
        {
            if (Instance == this)
                Instance = null;
        }
    }
}