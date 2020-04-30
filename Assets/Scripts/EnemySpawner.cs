﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy enemyPrefab; //The type limits the type of object that can be selected for the field
    [SerializeField] Transform parent;
    [Range(0.1f, 5f)] [SerializeField] float secondsBetweenSpawns = 2f;

    [SerializeField] Text countText;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Enemy newUnit = Instantiate(enemyPrefab, transform.position, Quaternion.identity, parent);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    private void Update()
    {
        int enemyCount = FindObjectsOfType<Enemy>().Length;
        countText.text = enemyCount.ToString();
    }
}
