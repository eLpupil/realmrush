using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] Text level;
    [SerializeField] Text gameOver;

    EnemySpawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        level.text = "Level: " + (SceneManager.GetActiveScene().buildIndex).ToString();
        spawner = FindObjectOfType<EnemySpawner>();
    }

    private void Update()
    {
        int baseHP = FindObjectOfType<BaseHealth>().hitPoints;

        if (baseHP < 1)
        {
            ProcessGameOver();
        }
        else if (baseHP > 0)
        {
            if (spawner.numberDestroyed == spawner.numberOfEnemies)
            {
                Invoke("LoadNextScene", 3f);
            }
        }
    }

    private void ProcessGameOver()
    {
        gameOver.text = "Game Over, Restarting Level";
        Invoke("ReloadScene", 3f);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void LoadNextScene() //referenced in string
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
