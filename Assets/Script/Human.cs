using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    private GameManager GM;

    private void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player Area"))
        {
            GM.AddScore(50);
            GM.AddHumanSaved();
            Destroy(gameObject);
        }

        if (collision.CompareTag("Enemy"))
        {
            GM.AddScore(-5);
            GM.AddHumanKilled();
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (GM.isPause) return;
        // GameOver
        GM.GameOver();
        Destroy(gameObject);
    }
}
