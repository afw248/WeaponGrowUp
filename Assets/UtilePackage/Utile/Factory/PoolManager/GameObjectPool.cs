namespace Fectory
{
    using System.Collections.Generic;
    using UnityEngine;

    public class GameObjectPool
    {
        private Transform _parent;
        private Stack<IPoolable> _pool;
        private IPoolable _prefab;

        public GameObjectPool(IPoolable prefab, Transform parent, int count)
        {
            this._parent = parent;
            this._prefab = prefab;
            _pool = new();
            for (int i = 0; i < count; ++i)
            {
                Push(CreateItem());
            }
        }
        private IPoolable CreateItem()
        {
            var item = GameObject.Instantiate(_prefab.GameObject).GetComponent<IPoolable>();

            if (item == null)
            {
                Debug.LogAssertion($"{_prefab.ItemName} is an object that cannot be Pooling");
                return null;
            }

            var go = item.GameObject;
            go.name = _prefab.ItemName;
            go.transform.SetParent(_parent);

            return item;
        }
        public IPoolable Pop()
        {
            IPoolable item = _pool.Count == 0 ? CreateItem() : _pool.Pop();
            item.GameObject.SetActive(true);
            item.ResetItem();

            return item;
        }
        public void Push(IPoolable item)
        {
            item.GameObject.SetActive(false);
            _pool.Push(item);
        }
    }
}