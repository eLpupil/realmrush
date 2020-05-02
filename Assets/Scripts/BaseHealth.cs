using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{
    public int hitPoints = 20;
    [SerializeField] int hpDecrease = 1;

    [SerializeField] Text baseHPText;
    [SerializeField] AudioClip enemyDeathSFX;


    public void ProcessEnemyHitBase()
    {
        if (hitPoints > 0)
        {
            hitPoints = hitPoints - hpDecrease;
            GetComponent<AudioSource>().PlayOneShot(enemyDeathSFX);
        }
    }

    public void Update()
    {
        baseHPText.text = "Base Health: " + hitPoints.ToString();
    }
}
