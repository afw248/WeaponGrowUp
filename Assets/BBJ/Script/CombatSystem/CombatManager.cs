namespace CombatSystem
{
    using UnityEngine;
    using Agent;
    using Weapon;
    using Visual;

    public class CombatManager : MonoBehaviour
    {
        public VisualRoot PlayerVisual;
        public VisualRoot EnemyVisual;
        public VisualRoot WeaponVisual;

        private IAgent _player;
        private IAgent _enemy;

        public WeaponFectory[] PlayerWeapon;

        // 스테이지 메니저   => 스테이지 정보

        // 무기 메니저       => 어떤 무기, 얼마나 강화
        // 현재 스테이지 정보 => 라운드, 에너미의 정보

        // 전투 메니저
        public void Awake()
        {
            var playerWeaponFectory = PlayerWeapon;
            var playerWeapon = new IWeapon[playerWeaponFectory.Length];
            for (int i = 0; i < playerWeapon.Length; ++i)
                playerWeapon[i] = playerWeaponFectory[i].CreateWeapon(WeaponVisual);

            _player = new Player(playerWeapon, PlayerVisual);

            _enemy = new Enemy(99999, EnemyVisual);
        }
        private void Update()
        {
            if (Input.anyKeyDown)
            {
                Debug.Log("인풋 입력");
                _player.Weapon.Execute();
            }
        }
    }
}