using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    public Vector3 direction;
    private GameManager GM;

    private void Start()
    {
        GM = FindObjectOfType<GameManager>();
        int ran = Random.Range(1, 5);

        switch (ran)
        {
            case 1:
                direction = GM.straight;
                break;
            case 2:
                direction = GM.slightlyLeft;
                break;
            case 3:
                direction = GM.slightlyRight;
                break;
            case 4:
                direction = GM.Left;
                break;
            case 5:
                direction = GM.Right;
                break;
        }
    }
    private void Update()
    {
        if (GM.isPause) return;
        MovingDown();
    }

    private void MovingDown()
    {
        transform.Translate(direction * Time.deltaTime * (GM.enemySpeed + .2f * GM.waveTotal/5.0f));
    }

    
}
