using Cost;
using System;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class CoinManager : MonoBehaviour
{
    private static CoinManager instance;
    public static CoinManager Instance { get { return instance; } }

    [field: SerializeField] public CostSO costSo { get; private set; }
    [field:SerializeField]public PopUiListSO popUiList { get; private set; }
    [field:SerializeField]public TextIcon TextIcon { get; set; }
    public Action PopUpText { get; set; }
    public int Cost
    {
        get { return costSo.Value; }
        set
        {
            if (costSo.Value != value)
            {
                costSo.Value = value;            
            }
        }
    }

    public UnityEvent<int> OnCostChanged;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            if (costSo != null)
            {
                costSo.NotifyEvent += (prev, next) => OnCostChanged?.Invoke(next);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            UpGradeReset();
        }
        if (Keyboard.current.aKey.wasPressedThisFrame) 
        {
            Cost += 1000;
        }
    }
    private void Start()
    {
        OnCostChanged?.Invoke(costSo.Value);
    }
    public bool Updates(int Values)
    {
       bool checkCoin  = costSo.TryUseable(Values);
       return checkCoin;
    }
    public void UpGradeReset() 
    {
        popUiList.CoinReset();
        PopUpText?.Invoke();
    }
}