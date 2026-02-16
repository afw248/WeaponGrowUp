namespace Projectile
{
    using UnityEngine;

    public class ProjectileBuilder
    {
        private GameObject _projectilePrefab;
        private float _speed;
        private float _duration;

        public ProjectileBuilder WithProjectilePrefab(GameObject projectilePrefab)
        {
            this._projectilePrefab = projectilePrefab;
            return this;
        }
        public ProjectileBuilder WithSpeed(float speed)
        {
            this._speed = speed;
            return this;
        }
        public ProjectileBuilder WithDuration(float duration)
        {
            this._duration = duration;
            return this;
        }
        public GameObject Build(Transform origin)
        {
            GameObject go = GameObject.Instantiate(_projectilePrefab, origin.position, origin.rotation);
            Projectile projectile = new();

            projectile.Initialize(go, _speed, _duration);

            return go;
        }
    }
}