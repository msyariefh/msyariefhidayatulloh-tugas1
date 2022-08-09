using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameManager GM;
    private void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player Area")) return;

        // Do something if player unable to hit enemy until finish line
        GM.ChangeLives(-1);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        if (GM.isPause) return;
        GM.AddScore(10);
        GM.AddEnemyKilled();
        Destroy(gameObject);
    }
}
