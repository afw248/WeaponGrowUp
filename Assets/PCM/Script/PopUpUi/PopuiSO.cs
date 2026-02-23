using UnityEngine;

[CreateAssetMenu(fileName = "PopuiSO", menuName = "SO/PopuiSO")]
public class PopuiSO : ScriptableObject
{
    [field:SerializeField]public string PopText {get; private set;}
    [field: SerializeField] public int Coin { get; set;}
    [field: SerializeField]public int AddCoin {get; private set;}

    [field: SerializeField] public int OriginCoin;
    public int UpGrade()
    {
        Coin += AddCoin;
        return Coin;
    }
}
