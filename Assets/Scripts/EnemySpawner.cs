using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy enemyPrefab; //The type limits the type of object that can be selected for the field
    [SerializeField] Transform parent;
    public int numberOfEnemies;
    [Range(0.1f, 5f)] [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] float secondsBeforeSpawn = 3f;

    [SerializeField] AudioClip enemySpawnSFX;

    public int numberDestroyed;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(secondsBeforeSpawn);

        for (int i = 0; i < numberOfEnemies; i++)
        {
            Enemy newUnit = Instantiate(enemyPrefab, transform.position, Quaternion.identity, parent);
            GetComponent<AudioSource>().PlayOneShot(enemySpawnSFX);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
