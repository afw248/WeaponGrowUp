namespace Timer
{
    using System;

    public interface ITimer
    {
        public bool IsDelaying { get; }
        public void DelayCall(float delayTime,Action callBack);
        public void DelayCall(float delayTime);
    }
}