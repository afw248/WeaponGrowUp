namespace Projectile
{
    using UnityEngine;
    using UpdateManager;
    using Timer;
    public class Projectile : IFixedUpdateObserver
    {
        public GameObject _visual;
        public float _speed;

        public void Dispose()
        {
            Debug.Log("ÃÑ¾ËÀÌ Á×¾ú¾î¿ä");
            FixedUpdateManager.UnregisterOvserver(this);
            GameObject.Destroy(_visual);
        }
        public void Initialize(GameObject visual,float speed, float duration)
        {
            this._speed = speed;
            this._visual = visual;
            FixedUpdateManager.RegisterOvserver(this);
            new Timer().DelayCall(duration,Dispose);
        }

        public void ObservedFixedUpdate()
        {
            if(_visual !=null)
            _visual.transform.position += _visual.transform.right * _speed;
        }
    }
}