using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isPause = false;
    public bool isOver = false;

    [Header("Enemy")]
    public float enemySpeed;

    [Header("Human")]
    public float humanSpeed;

    [Header("Movement Variations")]
    public Vector3 straight;
    public Vector3 slightlyLeft;
    public Vector3 Left;
    public Vector3 slightlyRight;
    public Vector3 Right;

    [Header("Spawn Mechanism")]
    public float cooldown;
    [Range(1, 10)] public int totalEnemyToBeSpawned;

    [Header("UI")]
    public int maxLives;
    public ScoreController ScoringUI;
    public GameObject PauseCanvas;
    public GameObject GameOverCanvas;
    [HideInInspector] public int waveTotal = 0;

    public void AddScore(int addition)
    {
        if (addition < 0 && ScoringUI.score <= 0) return;
        ScoringUI.score += addition;
    }

    public void ChangeLives(int change)
    {
        ScoringUI.playerLives += change;
    }

    public void AddEnemyKilled()
    {
        ScoringUI.enemyKilled ++;
    }

    public void AddHumanKilled()
    {
        ScoringUI.humanKilled++;
    }

    public void AddHumanSaved()
    {
        ScoringUI.humanSaved++;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOver)
            {
                Restart();
                return;
            }
            if (isPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isOver || isPause) MainMenu();
        }
    }

    public void Pause()
    {
        PauseCanvas.SetActive(true);
        isPause = true;
    }

    public void Resume()
    {
        PauseCanvas.SetActive(false);
        isPause = false;
    }

    public void GameOver()
    {
        GameOverCanvas.SetActive(true);
        isPause = true;
        isOver = true;
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
