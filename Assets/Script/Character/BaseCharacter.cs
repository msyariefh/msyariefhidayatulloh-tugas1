using UnityEngine;

namespace HiDE.ZombieTap.Character
{
    public abstract class BaseCharacter : MonoBehaviour, IRaycastable
    {
        [SerializeField] protected int points;
        [SerializeField] protected float speed;
        [SerializeField] protected float yLimit;
        protected Vector3 direction;

        protected virtual void Start()
        {
            direction = new Vector3(0, -1, 0);
        }

        protected virtual void Update()
        {
            Move();
            if (transform.position.y <= yLimit) OnBorderPassed();
        }
        private void Move()
        {
            transform.Translate(speed * Time.deltaTime * direction);
        }
        protected abstract void OnTapped();
        protected virtual void DestroyObject()
        {
            gameObject.SetActive(false);
        }

        protected abstract void OnBorderPassed();

        public void OnTap()
        {
            OnTapped();
            
        }
    }
}


