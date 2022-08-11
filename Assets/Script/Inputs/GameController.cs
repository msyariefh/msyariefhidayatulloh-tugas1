using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HiDE.ZombieTap.Spawner;
using HiDE.ZombieTap.Character;

namespace HiDE.ZombieTap.Inputs
{
    public class GameController : MonoBehaviour
    {
        public delegate void ChangeWaveAction(int wave);
        public static event ChangeWaveAction OnChangeWave;

        public delegate void ChangeScoreAction(int score);
        public static event ChangeScoreAction OnChangeScore;

        public delegate void ChangeHeart(int heart);
        public static event ChangeHeart OnChangeHeart;

        private int waveNumber = 1;
        private int _waveNumber = 1;
        private int score = 0;
        private int _score = 0;
        [SerializeField] private int maxHeart;
        private int currentHeart;
        private int _currentHeart;

        private void Start()
        {
            ObjectFactory.OnWaveStarted += OnWaveStarted;
            ObjectFactory.OnWaveCompleted += OnWaveCompleted;

            ZombieCharacter.OnEnemyPassed += OnEnemyPassed;
            SpecialZombieCharacter.OnEnemyPassed += OnEnemyPassed;
            ZombieCharacter.OnEnemyTapped += AddScore;
            SpecialZombieCharacter.OnEnemyTapped += AddScore;

            HumanCharacter.OnHumanPassed += AddScore;
            HumanCharacter.OnHumanTapped += GameOver;

            currentHeart = maxHeart;
            _currentHeart = currentHeart;
        }

        private void Update()
        {
            if (waveNumber != _waveNumber)
            {
                OnChangeWave?.Invoke(waveNumber);
                _waveNumber = waveNumber;
            }

            if(score != _score)
            {
                OnChangeScore?.Invoke(score);
                _score = score;
            }

            if(currentHeart != _currentHeart)
            {
                if (currentHeart <= 0)
                {
                    //Dead
                    return;
                }
                OnChangeHeart?.Invoke(currentHeart);
                _currentHeart = currentHeart;
            }
        }

        private void OnWaveStarted(int totalSpawned)
        {
            //Do something to UI when new wave started
        }
        private void OnWaveCompleted()
        {
            waveNumber++;
        }
        private void OnEnemyPassed()
        {
            currentHeart--;
        }
        private void AddScore(int num)
        {
            score += num;
        }

        private void GameOver()
        {

        }
    }
}
