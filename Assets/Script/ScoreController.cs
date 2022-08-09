using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public TMP_Text scoreboard;
    public int score;
    public int m_score;

    private void Start()
    {
        score = 0;
        m_score = 0;
    }


    private void Update()
    {
        if(m_score != score)
        {
            scoreboard.text = Converter(score);
            m_score = score;
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
