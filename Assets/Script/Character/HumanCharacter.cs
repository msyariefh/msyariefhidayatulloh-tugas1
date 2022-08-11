using UnityEngine;

namespace HiDE.ZombieTap.Character
{
    public class HumanCharacter : BaseCharacter
    {
        public delegate void HumanTappedAction();
        public static event HumanTappedAction OnHumanTapped;
        public delegate void HumanPassedAction(int score);
        public static event HumanPassedAction OnHumanPassed;


        protected override void OnTapped()
        {
            OnHumanTapped?.Invoke();
        }

        protected override void OnBorderPassed()
        {
            OnHumanPassed?.Invoke(points);
            DestroyObject();
        }
    }

}
