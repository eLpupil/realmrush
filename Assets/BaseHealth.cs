using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] int hitPoints = 20;


    public void DecreaseHealth()
    {
        if (hitPoints > 0)
        {
            hitPoints = hitPoints - 1;
        }
        if (hitPoints < 1)
        {
            //todo maybe add base explosion fx
            //todo end game screen?
            print("game over");
        }
    }
}
