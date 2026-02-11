namespace Weapon
{
    using UnityEngine;
    public abstract class AttackStrategy : ScriptableObject, IAttackStrategy
    {
        public abstract void Attack(IReadOnlyWeaponData weapon);
    }
}