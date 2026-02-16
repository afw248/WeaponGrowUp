namespace Agent
{
    using UnityEngine;

    public abstract class AgentFectory: ScriptableObject
    {
        public abstract IAgent CreateAgent();
    }
}