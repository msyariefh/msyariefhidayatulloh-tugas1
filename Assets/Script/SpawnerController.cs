using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerController : MonoBehaviour
{
    public GameManager GM;

    public GameObject[] spawnerLocation;

    public GameObject[] objectToBeSpawned;

    public Slider sliderWave;

    private int spawnNumber;
    private float coolDownTime;

    private bool isSpawning = false;

    private void Start()
    {
        spawnNumber = GM.totalEnemyToBeSpawned;
        coolDownTime = GM.cooldown;

        
    }

    private void Update()
    {
        if (isSpawning == false && !GM.isPause && !GM.isOver)
        {
            isSpawning = true;
            spawnNumber = GM.totalEnemyToBeSpawned + Mathf.FloorToInt(GM.waveTotal/5);
            coolDownTime = GM.cooldown + Mathf.FloorToInt(0.8f * GM.waveTotal/5);
            sliderWave.maxValue = spawnNumber;
            LeanTween.value(sliderWave.value, spawnNumber, 1.0f)
                .setOnUpdate((float val) => sliderWave.value = val)
                .setOnComplete(() => StartCoroutine(Spawn(coolDownTime)));
        }
        
    }
    private IEnumerator Spawn(float cd)
    {
        
        
        GM.waveTotal += 1;
        print(spawnNumber);
        int count = 0;
        while(count < spawnNumber)
        {
            
            //Spawn
            // Decide which object to be spawned
            int objIndex = Random.Range(0, objectToBeSpawned.Length);
            // Decide which row to go
            int row = Random.Range(0, spawnerLocation.Length);

            if (!GM.isPause)
            {
                Instantiate(objectToBeSpawned[objIndex], spawnerLocation[row].transform.position, Quaternion.identity);
                LeanTween.value(sliderWave.value, spawnNumber - count - 1, cd / (spawnNumber - 1))
                .setOnUpdate((float val) => sliderWave.value = val);
                count++;
            }
            
            yield return new WaitForSeconds(cd / (spawnNumber - 1));
        }

        yield return new WaitForSeconds(cd / (spawnNumber - 2));
        isSpawning = false;
    }


}
