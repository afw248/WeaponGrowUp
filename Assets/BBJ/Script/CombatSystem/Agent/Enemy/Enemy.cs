namespace Agent
{
    using NotifyValue;
    using Weapon;
    using System;
    using Visual;

    public class Enemy : IAgent, IDamageable
    {
        private readonly NotifyValue<int> _health;
        private readonly IVisualRoot _visual;
        public event Action Dead;
        public IWeapon Weapon { get; }
        public IReadOnlyNotifyValue<int> Health => _health;

        public Enemy(int health, IVisualRoot visual)
        {
            this._health = new NotifyValue<int>(health);
            this._visual = visual;
            this.Weapon = null;
        }
        public Enemy(int health, IVisualRoot visual, Weapon weapon)
        {
            this._health = new NotifyValue<int>(health);
            this._visual = visual;
            this.Weapon = weapon;
        }

        public void OnDamaged(int demage)
        {
            demage = Math.Max(demage, 0);
            _health.Value -= demage;
            if (IsDead) OnDead();
        }

        public bool IsDead => _health.Value <= 0;
        public void OnDead() => Dead?.Invoke();
    }
}