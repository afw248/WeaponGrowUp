namespace Animation
{
    using CustomEditor;
    using UnityEngine;

    public class AnimationDataSO : ScriptableObject
    {
        [ReadOnly, SerializeField] private int hashCode;
        [SerializeField] private string hashString;
        public int HashCode => hashCode;
        private void OnValidate() => hashCode = Animator.StringToHash(hashString);
    }

}