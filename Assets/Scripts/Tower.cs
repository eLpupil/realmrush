using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Parameters")]
    // Parameters of each tower
    [SerializeField] Transform objectToPan;

    [SerializeField] float towerDamage = 5;
    [SerializeField] float attackRange = 30f;

    [SerializeField] ParticleSystem bullets;

    // State of each tower
    Transform targetEnemy;


    private void Start()
    {
    }




    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        TrackAndFire();
    }

    private void SetTargetEnemy()
    {
        //collect all enemy objects on screen
            //for each enemy calculate distance from tower
            //update shortest distance
            //return enemy object with shortest distance
        //assign return object to targetEnemy
    }

    private void TrackAndFire()
    {
        var bulletsEmission = bullets.emission;

        if (targetEnemy != null && enemyInRange())
        {
            objectToPan.LookAt(targetEnemy);
            bulletsEmission.enabled = true;
        }
        else
        {
            bulletsEmission.enabled = false;
        }
    }

    private bool enemyInRange()
    {
        return Vector3.Distance(targetEnemy.position, objectToPan.position) <= attackRange;
    }

    public float GetTowerDamage()
    {
        return towerDamage;
    }

}


