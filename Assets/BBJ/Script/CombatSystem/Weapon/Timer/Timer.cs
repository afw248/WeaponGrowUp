namespace Timer
{
    using System;
    using UnityEngine;
    using UpdateManager;

    public class Timer : ITimer, IUpdateObserver
    {
        public bool IsDelaying { get; private set; }
        private float startTime;
        private float duration;
        private Action callBack;
        public Timer()
        {
            UpdateManager.RegisterOvserver(this);
            IsDelaying = false;
        }

        public void DelayCall(float duration, Action callBack)
        {
            this.duration = duration;
            this.callBack = callBack;
            this.IsDelaying = true;
            this.startTime = Time.time;
        }

        public void DelayCall(float duration)
        {
            this.duration = duration;
            this.IsDelaying = true;
            this.startTime = Time.time;
        }

        public void ObservedUpdate(float deltaTime)
        {
            if(IsDelaying)
            {
                if(startTime + duration <= Time.time)
                {
                    IsDelaying = false;
                    callBack?.Invoke();
                    callBack = null;
                }
            }
        }

        public void Dispose()
        {
            UpdateManager.UnregisterOvserver(this);
        }
    }
}