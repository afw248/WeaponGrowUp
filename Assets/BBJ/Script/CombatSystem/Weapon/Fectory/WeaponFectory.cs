namespace Weapon
{
    using Timer;
    using UnityEngine;
    using Visual;

    [CreateAssetMenu(fileName = "WeaponFectory", menuName = "Weapon/Fectory")]
    public class WeaponFectory : ScriptableObject
    {
        [SerializeField] private AttackStrategy attack;
        [SerializeField] private float coolTime;
        public IWeapon CreateWeapon(IVisualRoot visual)
        {
            return new WeaponBilider()
                .WithProjectileVisual(visual)
                .WithAttack(attack)
                .WithCoolTime(coolTime)
                .Build();
        }
    }
    class WeaponBilider
    {
        private IVisualRoot _visual;
        private IAttackStrategy _attack;
        private float _coolTime;
        public WeaponBilider WithProjectileVisual(IVisualRoot visual)
        {
            this._visual = visual;
            return this;
        }
        public WeaponBilider WithAttack(IAttackStrategy attack)
        {
            this._attack = attack;
            return this;
        }
        public WeaponBilider WithCoolTime(float cooltime)
        {
            this._coolTime = cooltime;
            return this;
        }
        public Weapon Build()
        {
            Timer timer = new Timer();
            Weapon weapon= new Weapon(_visual,_attack,timer,_coolTime);
            return weapon;
        }
    }
}