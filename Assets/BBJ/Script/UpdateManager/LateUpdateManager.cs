namespace UpdateManager
{
    using System.Collections.Generic;
    using UnityEngine;

    public class LateUpdateManager : MonoBehaviour
    {
        private static List<ILateUpdateObserver> _observers = new List<ILateUpdateObserver>();
        private static List<ILateUpdateObserver> _pendingObservers = new List<ILateUpdateObserver>();
        private static int _currentIndex;

        private void Update()
        {
            for (_currentIndex = _observers.Count - 1; _currentIndex >= 0; --_currentIndex)
            {
                _observers[_currentIndex].ObservedLateUpdate();
            }

            _observers.AddRange(_pendingObservers);
            _pendingObservers.Clear();
        }

        public static void RegisterOvserver(ILateUpdateObserver observer)
        {
            _pendingObservers.Add(observer);
        }
        public static void UnregisterOvserver(ILateUpdateObserver observer)
        {
            _observers.Remove(observer);
            --_currentIndex;
        }
    }
}