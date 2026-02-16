namespace UpdateManager
{
    using System.Collections.Generic;
    using UnityEngine;

    public class FixedUpdateManager : MonoBehaviour
    {
        private static List<IFixedUpdateObserver> _observers = new List<IFixedUpdateObserver>();
        private static List<IFixedUpdateObserver> _pendingObservers = new List<IFixedUpdateObserver>();
        private static int _currentIndex;

        private void Update()
        {
            for (_currentIndex = _observers.Count - 1; _currentIndex >= 0; _currentIndex--)
            {
                _observers[_currentIndex].ObservedFixedUpdate();
            }

            _observers.AddRange(_pendingObservers);
            _pendingObservers.Clear();
        }

        public static void RegisterOvserver(IFixedUpdateObserver observer)
        {
            _pendingObservers.Add(observer);
        }
        public static void UnregisterOvserver(IFixedUpdateObserver observer)
        {
            _observers.Remove(observer);
            --_currentIndex;
        }
    }
}