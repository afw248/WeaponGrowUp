namespace Stage
{
    using UnityEngine;
    using Agent;

    public class StageInfoSO: ScriptableObject
    {
        public AgentFectory[] enemyFectory;
        public BootyDataSO[] enemyBooty;

        public AgentFectory bossFectory;
        public BootyDataSO bossBooty;

        // 패배 조건은 따로 추가
        // 시간이 지나면 패배
        // 사용할 수 있는 무기가 없으면 패배
        // 이런 식으로
        // 이벤트를 이용해서 승패판정
    }
}