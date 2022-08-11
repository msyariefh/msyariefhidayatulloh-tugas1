using UnityEngine;

namespace HiDE.ZombieTap.Character
{
    public class ZombieCharacter : BaseCharacter
    {
        public delegate void EnemyPassedAction();
        public static event EnemyPassedAction OnEnemyPassed;
        public delegate void EnemyTappedAction(int score);
        public static event EnemyTappedAction OnEnemyTapped;
        protected override void OnBorderPassed()
        {
            OnEnemyPassed?.Invoke();
        }

        protected override void OnTapped()
        {
            OnEnemyTapped?.Invoke(points);
            DestroyObject();
        }
    }
}

