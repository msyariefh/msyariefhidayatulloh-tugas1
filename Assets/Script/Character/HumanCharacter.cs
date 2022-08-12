using UnityEngine;

namespace HiDE.ZombieTap.Character
{
    public class HumanCharacter : BaseCharacter
    {
        public delegate void HumanTappedAction();
        public static event HumanTappedAction OnHumanTapped;
        public delegate void HumanPassedAction(int score);
        public static event HumanPassedAction OnHumanPassed;
        public delegate void HumanKilledAction(int score);
        public static event HumanKilledAction OnHumanKilled;


        protected override void OnTapped()
        {
            OnHumanTapped?.Invoke();
        }

        protected override void OnBorderPassed()
        {
            OnHumanPassed?.Invoke(points);
            DestroyObject();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag("Enemy")) return;
            OnHumanKilled?.Invoke(-(points * 2));
            DestroyObject();
        }
    }

}
