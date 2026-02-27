using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BoostPopUiSO", menuName = "Scriptable Objects/BoostPopUiSO")]
public class UpGradeStatSO : CoinConsumeSO
{
    [SerializeField]private StatType index;
    [field: SerializeField] public float UpGradeStat {  get; set; }
    [field: SerializeField] public float StatMagn { get; set; } = 0.1f;

    public event Action<StatType, float> StatUp;
    public void StatUpMagn()
    {
        int UpGradeStatMagn = (int)Mathf.Round(UpGradeStat * this.StatMagn);
        UpGradeStat += UpGradeStatMagn;
        Debug.Log($"{UpGradeStat},{index} ");
        StatUp.Invoke(index , UpGradeStat);
    }
}
