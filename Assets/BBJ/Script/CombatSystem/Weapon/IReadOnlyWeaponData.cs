namespace Weapon
{
    using System;
    using UnityEngine;
    public interface IReadOnlyWeaponData
    {
        public Transform Origin { get; }
        public event Action Executed;
    }
}