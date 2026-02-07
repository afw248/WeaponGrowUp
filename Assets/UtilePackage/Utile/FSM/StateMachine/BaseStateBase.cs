namespace SateMachine
{
    public abstract class BaseState<TContext> : IState
    {
        public virtual void FixedUpdate()
        {
            // Noop
        }

        public virtual void OnEnter()
        {
            // Noop
        }

        public virtual void OnExit()
        {
            // Noop
        }

        public virtual void Update()
        {
            // Noop
        }
    }
}