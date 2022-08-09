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
        if (isSpawning == false) StartCoroutine(Spawn(coolDownTime));
    }
    private IEnumerator Spawn(float cd)
    {
        isSpawning = true;
        // Decide which row to go
        int row = Random.Range(0, spawnerLocation.Length);

        int count = 0;
        while(count < spawnNumber)
        {
            
            //Spawn
            // Decide which object to be spawned
            int objIndex = Random.Range(0, objectToBeSpawned.Length);

            if (!GM.isPause)
            {
                Instantiate(objectToBeSpawned[objIndex], spawnerLocation[row].transform.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(cd / (spawnNumber - 1));

            count++;
        }

        yield return new WaitForSeconds(cd / (spawnNumber - 1));
        isSpawning = false;
    }


}
