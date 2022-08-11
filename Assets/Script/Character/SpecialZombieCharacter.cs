using System.Collections;
using UnityEngine;

namespace HiDE.ZombieTap.Character
{
    public class SpecialZombieCharacter : BaseCharacter
    {
        private bool isTurning = false;
        protected override void Update()
        {
            if(!isTurning) StartCoroutine(ZigZagMovement());
            if (transform.position.x <= -8 || transform.position.x > 8) direction.x = 0;
            base.Update();
            
        }

        public delegate void EnemyPassedAction();
        public static event EnemyPassedAction OnEnemyPassed;
        public delegate void EnemyTappedAction(int score);
        public static event EnemyTappedAction OnEnemyTapped;

        protected override void OnBorderPassed()
        {
            OnEnemyPassed?.Invoke();
            DestroyObject();
        }

        protected override void OnTapped()
        {
            OnEnemyTapped?.Invoke(points);
            DestroyObject();
        }

        IEnumerator ZigZagMovement()
        {
            isTurning = true;
            int random = Random.Range(1, 4);
            switch (random)
            {
                case 1:
                    direction.x = -1.5f;
                    break;
                case 2:
                    direction.x = 0;
                    break;
                case 3:
                    direction.x = 1.5f;
                    break;
            }
            yield return new WaitForSeconds(.3f);
            isTurning = false;
        }

    }
}

