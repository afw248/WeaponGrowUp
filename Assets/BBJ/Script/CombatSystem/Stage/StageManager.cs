namespace Stage
{
    using UnityEngine;
    using Agent;

    public class StageManager : MonoBehaviour
    {
        public Stage _currentStage = new Stage(null,null,0);

        public IAgent GetCurrentEnemy()
        {
            var stage = _currentStage;
            var index = stage.CurrentIndex;
            var enemy = stage.GetEnemyOfIndex(index);
            stage.NextIndex();
            return enemy;
        }
        public IAgent GetCurrentBoss()
        {
            var stage = _currentStage;
            var boss = stage.GetBoss();
            return boss;
        }
        private void NextStage()
        {
        }
    }
}