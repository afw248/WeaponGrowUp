using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace CJW._00.Scripts.ForgeScripts.Models
{
    public class ForgeModel
    {
        private List<int> _idList = new();
        private int[] _equipIds = new int[4];
        public IReadOnlyList<int> DaggerIds => _idList;
        public IReadOnlyList<int> EquipIds => _equipIds;
        private string _savePath;
        private int _spawnId = 1;
        public int SpawnId => _spawnId;
        public ForgeModel()
        {
            Type t = GetType();
            _savePath = Path.Combine(Application.persistentDataPath, $"{t.FullName}.json");
            Load();
        }

        public void Add(int id)
        {
            _idList.Add(id);
        }

        public void EquipDagger(int id, int index) => _equipIds[index] = id;
        public void UnequipDagger(int id, int index) => _equipIds[index] = 0;
        public void Remove(int id) => _idList.Remove(id);
        public void UpgradeSpawnLevel() => _spawnId++;
        public void Load()
        {
            if (!File.Exists(_savePath))
            {
                _idList.Add(1); // default 아이템
                _equipIds = new int[4];
                Save();
            }

            string json = File.ReadAllText(_savePath);
            var data = JsonUtility.FromJson<DaggerSaveData>(json);
            _idList = data.daggerIdList;
            _equipIds = data.equipIdList;
            _spawnId = data.spawnLevel;
        }
        
        public void Save()
        {
            var data = new DaggerSaveData();
            data.daggerIdList = _idList;
            data.spawnLevel = SpawnId;
            data.equipIdList = _equipIds;
            
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(_savePath, json);
        }
    }
    
    [Serializable]
    public class DaggerSaveData
    {
        public int spawnLevel;
        public List<int> daggerIdList = new();
        public int[] equipIdList = new int[4];
    }
}