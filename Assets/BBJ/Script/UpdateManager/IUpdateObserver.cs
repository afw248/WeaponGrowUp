using System;

namespace UpdateManager
{
    public interface IUpdateObserver: IDisposable
    {
        public void ObservedUpdate(float deltaTime);
    }
}