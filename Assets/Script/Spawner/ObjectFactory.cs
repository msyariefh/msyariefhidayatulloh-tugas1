using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HiDE.ZombieTap.Inputs;
using HiDE.ZombieTap.Character;

namespace HiDE.ZombieTap.Spawner
{
    public class ObjectFactory : MonoBehaviour
    {
        private List<CharacterObject> characterPools;
        [SerializeField] private CharacterObject[] characters;
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private float initialSpawnCooldown;
        [SerializeField] private int initialNumberSpawning;

        public delegate void WaveStart(int totalSpawn);
        public static event WaveStart OnWaveStarted;
        public delegate void WaveSpawn(int running);
        public static event WaveSpawn OnWaveSpawn;
        public delegate void WaveComplete();
        public static event WaveComplete OnWaveCompleted;

        private void Awake()
        {
            characterPools = new List<CharacterObject>();
        }
        private void Start()
        {
            GameController.OnChangeWave += OnSpawnNewWave;
            OnSpawnNewWave(1);
        }

        void OnSpawnNewWave (int wave)
        {
            StartCoroutine(SpawnWave(wave));
        }

        IEnumerator SpawnWave( int wave)
        {
            int spawningNumber = initialNumberSpawning + Mathf.FloorToInt(wave / 5);
            float cooldown = initialSpawnCooldown + Mathf.FloorToInt(0.8f * wave / 5);
            OnWaveStarted?.Invoke(spawningNumber);
            int keeper = 0;
            while (keeper < spawningNumber)
            {
                yield return new WaitForSeconds(cooldown / (spawningNumber - 1));
                CharacterObject co = characters[Random.Range(0, characters.Length)];
                Vector3 pos = spawnPoints[Random.Range(0, spawnPoints.Length)].position;

                if (characterPools.Count <= 0)
                {
                    InstantiateObject(co, pos);
                }
                else
                {
                    CharacterObject coo = GetPoolObject(co.Type);
                   
                    if (coo != null)
                    {
                        coo.IsInUse = true;
                        coo.ObjectGame.transform.position = pos;
                        coo.ObjectGame.SetActive(true);
                    }
                    else
                    {
                        InstantiateObject(co, pos);
                    }
                    
                }
                OnWaveSpawn?.Invoke(spawningNumber - (keeper + 1));
                
                keeper++;
            }
            yield return new WaitForSeconds(cooldown/3);
            OnWaveCompleted?.Invoke();
        }

        void InstantiateObject(CharacterObject co, Vector2 pos)
        {
            CharacterObject co2 = new CharacterObject();
            co2.ObjectGame = Instantiate(co.ObjectGame, pos, Quaternion.identity);
            co2.IsInUse = true;
            co2.Type = co.Type;
            characterPools.Add(co2);
        }


        CharacterObject GetPoolObject(CharacterObject.CharacterType type)
        {
            ChecklistPoolObject();
            return characterPools.Find(obj => obj.Type == type && obj.IsInUse == false);
        }

        void ChecklistPoolObject()
        {

            foreach(CharacterObject chr in characterPools)
            {
                if (!chr.ObjectGame.activeSelf) chr.IsInUse = false;
            }
        }
    }

    
}
