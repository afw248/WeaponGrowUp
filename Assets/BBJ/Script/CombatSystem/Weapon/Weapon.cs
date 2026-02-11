namespace Weapon
{
    using System;
    using Timer;
    using UnityEngine;
    using Visual;
    using Random = UnityEngine.Random;
    public class Weapon : IWeapon, IReadOnlyWeaponData
    {
        protected readonly IAttackStrategy attackStrategy;
        protected readonly IVisualRoot visual;

        protected readonly ITimer timer;
        protected readonly float coolTime;

        public event Action Executed;
        public Transform Origin => visual.ModuleSlot;
        public Weapon(IVisualRoot visual, IAttackStrategy attackStrategy, ITimer timer, float coolTime)
        {
            this.attackStrategy = attackStrategy;
            this.visual = visual;
            this.timer = timer;
            this.coolTime = coolTime;
        }
        public Weapon(IVisualRoot visual, IAttackStrategy attackStrategy)
        {
            this.attackStrategy = attackStrategy;
            this.visual = visual;
        }
        public void Execute()
        {
            if (timer != null)
            {
                if (timer.IsDelaying == true)
                    return;
                else if (coolTime > 0)
                    timer.DelayCall(coolTime);
            }

            Debug.Log("무기 사용");
            attackStrategy?.Attack(this);
            Executed?.Invoke();
            var r = visual.VisualTransform.rotation;
            r.z += Random.value - 0.5f;
            visual.VisualTransform.rotation = r;
        }
    }
}