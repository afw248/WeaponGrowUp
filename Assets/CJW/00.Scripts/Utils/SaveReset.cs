using System.IO;
using UnityEngine;

namespace CJW._00.Scripts.Utils
{
    public static class SaveReset
    {
        public static void Reset()
        {
            string path = Application.persistentDataPath;
            if (Directory.Exists(path))
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                FileInfo[] files = dir.GetFiles("*.json");
                Debug.Log(files.Length);
                foreach (var file in files)
                {
                    file.Delete();
                }
            }
        }
    }
}