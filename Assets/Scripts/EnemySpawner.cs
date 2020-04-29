using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyMovement enemyPrefab; //The type limits the type of object that can be selected for the field
    [SerializeField] Transform parent;
    [Range(0.1f, 5f)] [SerializeField] float secondsBetweenSpawns = 2f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < 10; i++)
        {
            EnemyMovement newUnit = Instantiate(enemyPrefab, transform.position, Quaternion.identity, parent);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
        
    }
}
