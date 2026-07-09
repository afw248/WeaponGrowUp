using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStatUi : MonoBehaviour
{
    [SerializeField] private PlayerStatSO _plystat;
    [SerializeField]private PopUiListSO _pop;
   private void OnEnable()
   {
        foreach(var p in _pop.popuiSOList)
        {
            p.StatUp += StatUp;
        }
   }
   public void StatUp(StatType type , float value)
   {
        _plystat.AddModifier(type , value); 
        Debug.Log(_plystat.FinalAttack);
   } 
}
