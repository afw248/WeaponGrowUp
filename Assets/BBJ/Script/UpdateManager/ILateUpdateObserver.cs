using System;

namespace UpdateManager
{
    public interface ILateUpdateObserver : IDisposable
    {
        public void ObservedLateUpdate();
    }
}