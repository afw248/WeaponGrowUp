namespace UpdateManager
{
    using System.Collections.Generic;
    using UnityEngine;

    public class UpdateManager : MonoBehaviour
    {
        private static List<IUpdateObserver> _observers = new List<IUpdateObserver>();
        private static List<IUpdateObserver> _pendingObservers = new List<IUpdateObserver>();
        private static int _currentIndex;

        private void Update()
        {
            for(_currentIndex = _observers.Count -1; _currentIndex >=0; --_currentIndex)
            {
                _observers[_currentIndex].ObservedUpdate(Time.deltaTime);
            }

            _observers.AddRange(_pendingObservers);
            _pendingObservers.Clear();
        }

        public static void RegisterOvserver(IUpdateObserver observer)
        {
            _pendingObservers.Add(observer);
        }
        public static void UnregisterOvserver(IUpdateObserver observer)
        {
            _observers.Remove(observer);
            --_currentIndex;
        }
    }
}