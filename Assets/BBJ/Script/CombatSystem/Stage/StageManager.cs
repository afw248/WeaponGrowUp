namespace Stage
{
    using UnityEngine;
    using Agent;
    using Math = System.Math;
    public class StageManager : MonoBehaviour
    {
        public StageListSO StageList;
        private int StageLength;

        private Stage _currentStage;
        private int _currentIndex;
        private int Index
        {
            get => _currentIndex;
            set
            {
                value = Math.Clamp(value, 0, StageLength);
                _currentStage = CreateStage(StageList.list[value]);
                _currentIndex = value;
            }
        }
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
        public void NextStage() => ++Index;

        private Stage CreateStage(StageInfoSO stageInfoSO)
        {

            return null;
        }
    }
}