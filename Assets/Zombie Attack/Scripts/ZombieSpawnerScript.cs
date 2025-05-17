using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ZombieSpawnerScript : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform target;

    public float spawnRange = 10;

    public UnityEvent ZombieDied;

    void Start()
    {
        // LESSON 3-4: Replace code below.
        StartCoroutine(ZombieSpawnRepeater());
    }

    public Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-spawnRange,spawnRange), 1, Random.Range(-spawnRange,spawnRange));
    }

    public void SpawnZombie()
    {
        GameObject zombie = Instantiate(zombiePrefab);
        zombie.transform.position = RandomPosition();
        ZombieScript zombieScript = zombie.GetComponent<ZombieScript>();
        zombieScript.Init(target, this);
    }

    public void ZombieHasDied()
    {
        ZombieDied?.Invoke();
    }

    // LESSON 3-4: Add coroutine below.
    public IEnumerator ZombieSpawnRepeater()
    {
        yield return new WaitForSeconds(4f);
        SpawnZombie();
        StartCoroutine(ZombieSpawnRepeater());
    }
}
