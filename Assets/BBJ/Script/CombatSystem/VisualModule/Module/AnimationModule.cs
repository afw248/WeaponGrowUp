namespace Visual
{
    using Animation;
    using UnityEngine;
    public class AnimationModule : VisulModule
    {
        [SerializeField] private AnimationDataSO animationData;
        private Animator animator;

        public override void Attach(IReadOnlyVisualRoot root)
        {
            this.animator = GetOrAddComponent<Animator>(root);
        }

        public override void Detach()
        {
            DestroyComponent(this.animator);
        }

        public override void Update()
        {
            animator.SetTrigger(animationData.HashCode);
        }
    }
}