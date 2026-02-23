using Icon;
using System;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;

public class PopUi : MonoBehaviour
{
    [SerializeField]private PopuiSO popuiSO;
    [SerializeField] private TextIconDataSO _texticon;

    private Transform _money;
    public TextMeshProUGUI _moneyText { get; set; }

    private Transform _name;
    public TextMeshProUGUI _nameText { get; set; }
    private void Awake()
    {
        _money = transform.Find("UpGrade/MoneyText");
        _name = transform.Find("NameText");
    }

    private void Start()
    {                
        PopUitext();
    }
    private void OnEnable()
    {
        CoinManager.Instance.PopUpText += PopUitext;
    }
    public void PopUitext()
    {
        _moneyText = _money.GetComponent<TextMeshProUGUI>();
        _nameText = _name.GetComponent<TextMeshProUGUI>();
        _moneyText.text = string.Format($"{_texticon.ID}{popuiSO.Coin}");
        _nameText.text = string.Format($"{popuiSO.PopText}");
    }

    public void Register()
    {
        CoinManager.Instance.Updates(popuiSO.UpGrade());
        _moneyText.text = string.Format($"{_texticon.ID}{popuiSO.Coin}");
        Debug.Log("ad");
    }

}
