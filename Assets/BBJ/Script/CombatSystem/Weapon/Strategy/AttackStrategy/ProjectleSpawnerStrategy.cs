namespace Weapon
{
    using Projectile;
    using UnityEngine;
    [CreateAssetMenu(fileName = "ProjectileSpawnerSrategy", menuName = "Weapon/Attack/ProjectleSpawnerStrategy")]
    public class ProjectleSpawnerStrategy : AttackStrategy
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private float speed;
        [SerializeField] private float duration;
        public override void Attack(IReadOnlyWeaponData weapon)
        {
            Debug.Log("투사체 발사");

            new ProjectileBuilder()
                .WithProjectilePrefab(projectilePrefab)
                .WithSpeed(speed)
                .WithDuration(duration)
                .Build(weapon.Origin);
        }
    }
}