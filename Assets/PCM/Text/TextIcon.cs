using Icon;
using System;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class TextIcon : MonoBehaviour
{
    [SerializeField]private TextIconDataSO _iconData;
    public TextMeshProUGUI txt;

    private void Awake()
    {
        txt = GetComponent<TextMeshProUGUI>();  
    }
    public void OnText(int value)
    {
        Debug.Log("½ÇÇà");
        txt.text = string.Format($"{_iconData.ID}: {value}");
    }

}
