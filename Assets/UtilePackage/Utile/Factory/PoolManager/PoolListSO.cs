namespace Fectory
{
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "PoolList", menuName = "Pool/List")]
    public class PoolListSO : ScriptableObject
    {
        [field: SerializeField]
        public List<PoolItemSO> PoolList { get; private set; }
    }
}