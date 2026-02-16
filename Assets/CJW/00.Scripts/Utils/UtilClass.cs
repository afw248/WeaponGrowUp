using UnityEngine;
using UnityEngine.InputSystem;

namespace CJW._00.Scripts.Utils
{
    public static class UtilClass
    {
        public static Vector2 GetUIMousePos() => Mouse.current.position.ReadValue();
        public static Vector2 GetMousePos() => Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }
}