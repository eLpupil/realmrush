using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Tracking")]
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;

    [Header("Parameters")]
    [SerializeField] float towerDamage = 5;
    [SerializeField] float attackRange = 30f;

    [SerializeField] ParticleSystem bullets;

    private void Start()
    {
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


    // Update is called once per frame
    void Update()
    {
        TrackAndFire();
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


