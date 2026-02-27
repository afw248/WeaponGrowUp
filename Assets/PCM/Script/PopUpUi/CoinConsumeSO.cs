using System.Net.NetworkInformation;
using UnityEngine;

public abstract class CoinConsumeSO : ScriptableObject
{
    [field: SerializeField] public int OriginCoin { get; set; }
    [field:SerializeField]public string PopText {get; private set;}
    [field: SerializeField] public float CoinMagn { get; set; } = 0.1f;

    [SerializeField]private int coin;
    public  int Coin { get => coin; set { coin = Mathf.Clamp(value, OriginCoin, int.MaxValue); } }
    public virtual int CoinConsume()
    {
        int CoinMagn = (int)Mathf.Round(Coin * this.CoinMagn);
        Coin += CoinMagn;
        return Coin;
    }
}
