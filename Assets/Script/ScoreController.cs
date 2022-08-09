using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public GameManager GM;
    public TMP_Text scoreboard;
    public TMP_Text liveboard;
    public TMP_Text waveInfo;
    public TMP_Text enemyKilledStats;
    public TMP_Text humanKilledStats;
    public TMP_Text humanSavedStats;

    private int m_waveInfo;
    public int score;
    private int m_score;

    public int playerLives;
    private int m_playerLives;

    public int enemyKilled;
    private int m_enemyKilled;

    public int humanSaved;
    private int m_humanSaved;

    public int humanKilled;
    private int m_humanKilled;

    private void Start()
    {
        score = 0;
        m_score = 0;

        playerLives = GM.maxLives;
        m_playerLives = playerLives;

        m_waveInfo = GM.waveTotal;

        enemyKilled = 0;
        m_enemyKilled = enemyKilled;

        humanKilled = 0;
        m_humanKilled = humanKilled;

        humanSaved = 0;
        m_humanSaved = humanSaved;

        scoreboard.text = Converter(score);
        liveboard.text = playerLives.ToString();
        enemyKilledStats.text = enemyKilled.ToString();
        humanKilledStats.text = "Killed: " + humanKilled.ToString();
        humanSavedStats.text = "Saved: " + humanSaved.ToString();
    }


    private void Update()
    {
        if(m_score != score)
        {
            scoreboard.text = Converter(score);
            m_score = score;
        }

        if(playerLives != m_playerLives)
        {
            if (playerLives <= 0) GM.GameOver();
            liveboard.text = playerLives.ToString();
            m_playerLives = playerLives;
        }

        if(m_waveInfo != GM.waveTotal)
        {
            waveInfo.text = "Wave " + GM.waveTotal;
            m_waveInfo = GM.waveTotal;
        }
        
        if(enemyKilled != m_enemyKilled)
        {
            enemyKilledStats.text = enemyKilled.ToString();
            m_enemyKilled = enemyKilled;
        }

        if (humanSaved != m_humanSaved)
        {
            humanSavedStats.text = "Saved: " + humanSaved.ToString();
            m_humanSaved = humanSaved;
        }

        if (humanKilled != m_humanKilled)
        {
            humanKilledStats.text = "Killed: " + humanKilled.ToString();
            m_humanKilled = humanKilled;
        }

    }
    private string Converter(int num)
    {
        if (num >= 0 && num < 10) return "000000" + num;
        if (num >= 10 && num < 100) return "00000" + num;
        if (num >= 100 && num < 1000) return "0000" + num;
        if (num >= 1000 && num < 10000) return "000" + num;
        if (num >= 10000 && num < 100000) return "00" + num;
        if (num >= 100000 && num < 1000000) return "0" + num;

        return num.ToString();
    }
}
