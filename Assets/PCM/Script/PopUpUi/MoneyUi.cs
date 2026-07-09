using Icon;
using System;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;

public class MoneyUi : MonoBehaviour //이름 짓기 ㅈㄴ 애매함
{
    [SerializeField] protected UpGradeStatSO popuiSO;
    [SerializeField] protected TextIconDataSO _texticon;

    private Transform _money;
    public TextMeshProUGUI _moneyText { get; set; }
    private Transform _name;
    public TextMeshProUGUI _nameText { get; set; }
    private void Awake()
    {
        _money = transform.Find("UpGrade/MoneyText");
        _name = transform.Find("NameText");
        if (_money != null) _moneyText = _money.GetComponent<TextMeshProUGUI>();
        if (_name != null) _nameText = _name.GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        PopUitext();
        CoinManager.Instance.PopUpText += PopUitext;
    }
    public void PopUitext()
    {
        if (popuiSO.Coin <= 0) 
        {
            popuiSO.Coin = popuiSO.OriginCoin;
        }
        if (_moneyText != null)
            _moneyText.text = $"{_texticon.ID}{popuiSO.Coin}";

        if (_nameText != null)
            _nameText.text = popuiSO.PopText;
    }

    public void Register()
    {
        if (CoinManager.Instance.Updates(popuiSO.CoinConsume())) 
        {
            _moneyText.text = string.Format($"{_texticon.ID}{popuiSO.Coin}");
        }
        popuiSO.StatUpMagn();
    }

}
