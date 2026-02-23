using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "PopUiListSO", menuName = "Scriptable Objects/PopUiListSO")]
public class PopUiListSO : ScriptableObject
{
    public List<PopuiSO> popuiSO = new List<PopuiSO>();
    
    public void CoinReset()
    {
        for(int i = 0; i < popuiSO.Count; i++)
        {
            popuiSO[i].Coin = popuiSO[i].OriginCoin;
        }
    }
}
