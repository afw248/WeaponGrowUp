using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CJW._00.Scripts.Dagger.SO
{
    [CreateAssetMenu(fileName = "DaggerDataSoList", menuName = "SO/Dagger/DaggerDataSoList", order = 0)]
    public class DaggerDataSoList : ScriptableObject
    {
        public List<DaggerDataSo> list = new();

        public DaggerDataSo GetSo(int id)
        {
            var so = list.FirstOrDefault(x => x.daggerID == id);
            Debug.Log(id);
            return so;
        }
    }
}