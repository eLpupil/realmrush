using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;


    private void Start()
    {
        FireProjectile();
    }

    private void FireProjectile()
    {
        ParticleSystem.EmissionModule particleEmission = this.GetComponentInChildren<ParticleSystem>().emission;
        particleEmission.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        objectToPan.LookAt(targetEnemy);
    }


}


