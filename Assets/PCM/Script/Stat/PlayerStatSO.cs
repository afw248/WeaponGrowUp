using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerStatSO", menuName = "SO/PlayerStatSO")]
public class PlayerStatSO : ScriptableObject
{
    [Header("Base Stats")]
    public int baseAttack;
    public float baseAttackSpeed;
    public float baseCritical;

    private Dictionary<StatType, float> modifiers = new Dictionary<StatType, float>();
    // 최종 스탯 계산 프로퍼티
    [field:SerializeField]public float FinalAttack => baseAttack + (int)GetModifier(StatType.Attack);
    [field:SerializeField]public float FinalAttackSpeed => baseAttackSpeed + GetModifier(StatType.AttackSpeed);
    [field:SerializeField]public float FinalCritical => baseCritical + GetModifier(StatType.Critical);

    public void AddModifier(StatType type, float value)
    {
        if (!modifiers.ContainsKey(type))
            modifiers[type] = 0;

        modifiers[type] += value;
    }
    
    private float GetModifier(StatType type)
    {
        return modifiers.ContainsKey(type) ? modifiers[type] : 0;
    }
    private float GetAttackPostion(bool value, float magn)
    {
        if (value)
            return magn;
        else
            return 1;
        
    }
    public void ResetModifiers()
    {
        modifiers.Clear();
    }
}
