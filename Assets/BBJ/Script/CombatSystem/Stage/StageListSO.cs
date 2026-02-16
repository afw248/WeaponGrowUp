namespace Stage
{
    using UnityEngine;

    public class StageListSO:ScriptableObject
    {
        public StageInfoSO[] list { get; private set; }
    }
}