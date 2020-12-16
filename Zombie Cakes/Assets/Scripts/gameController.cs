using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{

    // here are some things to keep track of. This also includes the #'s for zombie count.
    int maxZombieCount = 50;
    public int currentZombieCount;
    int spawnInterval = 15;
    int tick = 0;

    // This is to setup our spawners and what enemy types we have included.

    public GameObject[] zombieSpawners;
    public GameObject[] enemyType;




    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < zombieSpawners.Length; i++)
        {
            zombieSpawners[i] = transform.GetChild(i).gameObject;
        }

    }


    // this is the function to actually spawn the zombies. This works based on the spawners we have indicated in our zombieSpawners array
    private void SpawnZombies()
    {

        tick++;

        if (tick > spawnInterval)
        {
            tick = 0;

            if (currentZombieCount < maxZombieCount)
            {
                int SpawnerID = Random.Range(0, zombieSpawners.Length);
                int RandomZombie = Random.Range(0, enemyType.Length);
                var newZombie = Instantiate(enemyType[RandomZombie], zombieSpawners[SpawnerID].transform.position, zombieSpawners[SpawnerID].transform.rotation);

                currentZombieCount++;

            } // end of zombie count check

        } // end of tick check

    }




    // Update is called once per frame
    void Update()
    {

        SpawnZombies();

    }
}
