namespace Agent
{
    using NotifyValue;
    using Visual;
    using Weapon;

    public class Player : IAgent
    {
        private readonly IWeapon[] _weapons;
        private readonly IVisualRoot _visual;
        private readonly NotifyValue<int> _currentIndex;
        public IWeapon Weapon  => _weapons[_currentIndex.Value];
        public IReadOnlyNotifyValue<int> CureentIndex => _currentIndex;

        public Player(IWeapon[] weapons,IVisualRoot visual , int index)
        {
            this._currentIndex = new NotifyValue<int>(index);
            this._visual = visual;
            this._weapons = weapons;
        }
        public Player(IWeapon[] weapons, IVisualRoot visual)
        {
            this._currentIndex = new NotifyValue<int>();
            this._visual = visual;
            this._weapons = weapons;
        }

        private int ClampIndex(int index, int length) => index >= length ? index = 0 : index;
        public void NextWeapon() => ClampIndex(++_currentIndex.Value, _weapons.Length);
    }

}