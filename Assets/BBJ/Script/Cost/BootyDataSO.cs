namespace Stage
{
    using UnityEngine;
    using Cost;

    [CreateAssetMenu(fileName = "Booty", menuName = "SO/Cost/Booty")]
    public class BootyDataSO : ScriptableObject
    {
        private CostSO bootyType;
        [SerializeField]private int bootyValue;

        // 전리품 이팩트 팩토리 필요
        // => 스프라이트 모양으로 떨어지는 거
    }
}