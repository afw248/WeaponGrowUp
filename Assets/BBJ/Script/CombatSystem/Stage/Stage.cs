namespace Stage
{
    using UnityEngine;
    using Agent;

    public class Stage
    {
        private IAgent[] _enemy;
        private IAgent _boss;
        //º¸»ó

        public int StageLength { get; private set; }
        public int CurrentIndex { get; private set; }

        public Stage(IAgent[] enemy,IAgent boss, int stageLength)
        {
            this._enemy = enemy;
            this._boss = boss;
            this.StageLength = stageLength;
            this.CurrentIndex = 0;
        }

        public IAgent GetEnemyOfIndex(int index)
        {
            index = ClampStageIndex(index);

            var enemy = _enemy[index];
            if (enemy == null) Debug.LogAssertion("Enemy is empty on stage.");

            return enemy;
        }
        public IAgent GetBoss()
        {
            IAgent boss = _boss;
            if (boss == null) Debug.LogAssertion("Boss is empty on stage.");

            return boss;
        }
        public void NextIndex()
        {
            int index = CurrentIndex + 1;
            index = ClampStageIndex(index);
            CurrentIndex = index;
        }
        public int ClampStageIndex(int index) => index % StageLength;
    }
}