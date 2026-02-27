using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "PopUiListSO", menuName = "Scriptable Objects/PopUiListSO")]
public class PopUiListSO : ScriptableObject
{
    public List<UpGradeStatSO> popuiSOList = new List<UpGradeStatSO>();
    
    public void CoinReset()
    {
        for(int i = 0; i < popuiSOList.Count; i++)
        {
            popuiSOList[i].Coin = popuiSOList[i].OriginCoin;
        }
    }
}
