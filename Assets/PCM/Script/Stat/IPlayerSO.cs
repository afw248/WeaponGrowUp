public interface IPlayerSO
{
    int FinalAttack { get; }
    float FinalAttackSpeed { get; }
    float FinalCritical { get; }

    void AddModifier(StatType type, float value);
    void ResetModifiers();
}