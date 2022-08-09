using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameManager GM;

    public GameObject[] spawnerLocation;

    public GameObject[] objectToBeSpawned;

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
            spawnNumber = GM.totalEnemyToBeSpawned + Mathf.FloorToInt(GM.waveTotal/10);
            coolDownTime = GM.cooldown + Mathf.FloorToInt(GM.waveTotal/10);
            StartCoroutine(Spawn(coolDownTime));
        }
        
    }
    private IEnumerator Spawn(float cd)
    {
        isSpawning = true;
        GM.waveTotal += 1;
        
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
            }
            yield return new WaitForSeconds(cd / (spawnNumber - 1));

            count++;
        }

        yield return new WaitForSeconds(cd / (spawnNumber - 2));
        isSpawning = false;
    }


}
