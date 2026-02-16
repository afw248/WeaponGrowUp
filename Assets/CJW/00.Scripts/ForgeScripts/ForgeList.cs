using System;
using System.Collections.Generic;
using System.IO;
using CJW._00.Scripts.Dagger.SO;
using UnityEngine;

namespace CJW._00.Scripts.ForgeScripts
{
    public class ForgeList : MonoBehaviour
    {
        [SerializeField] private DaggerDataSoList daggerList;
        [SerializeField] private GameObject template;
        [SerializeField] private GameObject mergeEffect;

        private List<int> _idList = new();
        private Dictionary<int, ForgeElement> _soDataBase = new();
        
        private BoxCollider2D _collider;
        public static ForgeList Instance;
        
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            _collider = GetComponent<BoxCollider2D>();
            
            Type t = GetType();
            string path = Path.Combine(Application.persistentDataPath, $"{t.FullName}.json");
            if (!File.Exists(path))
            {
                DaggerList list = new DaggerList();
                string defaultJson = JsonUtility.ToJson(list, true);
                File.WriteAllText(path, defaultJson);
            }
            string json = File.ReadAllText(path);
            var saveDaggerList = JsonUtility.FromJson<DaggerList>(json);
            
            foreach (var c in saveDaggerList.daggerIdList)
                MakeDagger(c);
            
            RefreshDaggers();
        }

        [ContextMenu("MakeDagger")]
        public void Test() => MakeDagger(1);
        
        public void MakeDagger(int id)
        {
            _idList.Add(id);
            
            GameObject element = Instantiate(template, transform);
            element.GetComponent<ForgeElement>().Initialize(daggerList.GetSo(id));
        }
        
        private void RefreshDaggers()
        {
            Vector2 size = _collider.bounds.size;
        }

        public void Merge(ForgeElement a, ForgeElement b)
        {
            if(a.So != b.So) return;

            Debug.Log(a.So.nextLevel);

            Instantiate(mergeEffect, a.transform.position, Quaternion.identity);
            
            _idList.Remove(a.So.daggerID);
            _idList.Remove(b.So.daggerID);
            
            Destroy(a.gameObject);
            Destroy(b.gameObject);
            
            MakeDagger(a.So.nextLevel);
        }
        
        private void OnApplicationQuit()
        {
            var list = new DaggerList();
            list.daggerIdList = _idList;
            
            Type t = GetType();
            string path = Path.Combine(Application.persistentDataPath, $"{t.FullName}.json");
            string json = JsonUtility.ToJson(list);
            
            File.WriteAllText(path, json);
        }
        
        [ContextMenu("Reset")]
        public void ResetData()
        {
            string path = Application.persistentDataPath;
            if (Directory.Exists(path))
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                FileInfo[] files = dir.GetFiles("*.json");

                foreach (var file in files)
                {
                    file.Delete();
                }
            }
        }
    }

    [Serializable]
    public class DaggerList
    {
        public List<int> daggerIdList = new();
    }
}
