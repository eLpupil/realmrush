using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [Header("Effects")]
    [SerializeField] GameObject explosionFX;
    [SerializeField] GameObject hitFX;

    [Header("Heatlh")]
    [SerializeField] float hitPoints = 100f;
    
    Tower towerType1 = new Tower();

    float damage;

    // Start is called before the first frame update
    void Start()
    {
    }


    private void OnParticleCollision(GameObject other)
    {
        switch (other.tag)
        {
            case "Tower Type 1":
                damage = towerType1.GetTowerDamage(); //address the warning
                break;
            default:
                damage = 1f;
                break;
        }

        ProcessHit(damage); 

        if (hitPoints < 1)
        {
            DestroyEnemy();
        }
    }

    private void DestroyEnemy()
    {
        //todo add explosionFX 
        Destroy(gameObject);
    }

    private void ProcessHit(float damage)
    {
        if (hitPoints > 0f)
        {
            //todo add hit animation hitFX
            hitPoints = hitPoints - damage;
        }
    }
}
