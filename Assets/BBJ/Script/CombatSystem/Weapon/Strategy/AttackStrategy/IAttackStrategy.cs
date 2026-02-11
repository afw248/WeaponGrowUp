namespace Weapon
{
    public interface IAttackStrategy
    {
        public void Attack(IReadOnlyWeaponData weapon);
    }
}