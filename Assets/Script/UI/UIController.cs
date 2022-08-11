using UnityEngine;
using TMPro;
using HiDE.ZombieTap.Inputs;
using HiDE.ZombieTap.Character;
using HiDE.ZombieTap.Spawner;
using UnityEngine.UI;

namespace HiDE.ZombieTap.UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreboard;
        [SerializeField] private TMP_Text liveboard;
        [SerializeField] private TMP_Text waveInfo;
        [SerializeField] private TMP_Text enemyKilledStats;
        [SerializeField] private TMP_Text humanSavedStats;
        [SerializeField] private GameObject gameOverPage;

        [SerializeField] private Slider slider;

        private int killedZombieCounter;
        private int savedHumanCounter;

        private void Start()
        {
            scoreboard.text = Converter(0);
            liveboard.text = "3";
            waveInfo.text = "1";

            killedZombieCounter = 0;
            savedHumanCounter = 0;

            //Events
            GameController.OnChangeScore += OnScoreChanged;
            GameController.OnChangeHeart += OnHeartChanged;
            GameController.OnChangeWave += OnWaveChanged;
            GameController.OnGameOver += OnGameOver;

            ObjectFactory.OnWaveStarted += OnWaveStarted;
            ObjectFactory.OnWaveSpawn += OnWaveSpawned;

            ZombieCharacter.OnEnemyTapped += OnEnemyTapped;
            SpecialZombieCharacter.OnEnemyTapped += OnEnemyTapped;
            HumanCharacter.OnHumanPassed += OnHumanPassed;
        }

        

        private void OnScoreChanged(int score)
        {
            scoreboard.text = Converter(score);
        }
        private void OnHeartChanged(int heart)
        {
            liveboard.text = heart.ToString();
        }
        private void OnWaveChanged(int wave)
        {
            waveInfo.text = wave.ToString();
        }
        private void OnEnemyTapped(int score)
        {
            killedZombieCounter++;
            enemyKilledStats.text = killedZombieCounter.ToString();
        }
        private void OnHumanPassed(int score)
        {
            savedHumanCounter++;
            humanSavedStats.text = savedHumanCounter.ToString();
        }

        private void OnWaveStarted(int spawnNumber)
        {
            slider.maxValue = spawnNumber;
            if (slider.value != spawnNumber) slider.value = spawnNumber;
            LeanTween.value(slider.value, spawnNumber, .75F)
                .setOnUpdate((float val) => slider.value = val);
        }

        private void OnWaveSpawned(int running)
        {
            LeanTween.value(slider.value, running, .5f)
                .setOnUpdate((float val) => slider.value = val);
        }

        private void OnGameOver()
        {
            gameOverPage.SetActive(true);
            Time.timeScale = 0;
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
}
