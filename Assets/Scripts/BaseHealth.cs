﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] int hitPoints = 20;
    [SerializeField] int hpDecrease = 1;

    [SerializeField] Text baseHPText;


    public void DecreaseHealth()
    {
        if (hitPoints > 0)
        {
            hitPoints = hitPoints - hpDecrease;
        }
        if (hitPoints < hpDecrease)
        {
            //todo maybe add base explosion fx
            //todo end game screen?
            print("game over");
        }
    }

    public void Update()
    {
        baseHPText.text = hitPoints.ToString();
    }
}