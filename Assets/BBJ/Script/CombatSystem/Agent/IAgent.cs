namespace Agent
{
    using Weapon;
    public interface IAgent 
    {
        public IWeapon Weapon { get; }
    }
}