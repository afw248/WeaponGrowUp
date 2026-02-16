using System;
using UnityEngine;

namespace CJW._00.Scripts.Dagger.SO
{
    [CreateAssetMenu(fileName = "DaggerDataSo", menuName = "SO/Dagger/DaggerDataSo", order = 0)]
    public class DaggerDataSo : ScriptableObject
    {
        public int daggerID;
        public int nextLevel;
        public StatData baseStat;
        public StatData upgradeStat;
        
        
        [Header("UI Data")]
        public Sprite icon;
        public string daggerName;
    }

    [Serializable]
    public struct StatData
    {
        public float damage;
        public float criticalPer;
        public float criticalDam;
    }
}