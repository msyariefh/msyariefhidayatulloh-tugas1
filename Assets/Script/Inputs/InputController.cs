using UnityEngine;

namespace HiDE.ZombieTap.Inputs
{
    public class InputController : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Collider2D rayObj = Physics2D.OverlapPoint(worldPoint);
                if (rayObj == null) return;

                rayObj.gameObject.GetComponent<IRaycastable>().OnTap();
            }
        }


    }
}

