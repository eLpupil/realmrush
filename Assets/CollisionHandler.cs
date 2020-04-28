using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject explosionFX;
    [SerializeField] GameObject hitFX;

    [SerializeField] float hitPoints = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

        if (hitPoints <= Mathf.Epsilon)
        {
            //play explosionFX 
            Destroy(gameObject);
            print("object destroyed");        }

    }

    private void ProcessHit()
    {
        if (hitPoints > 0f)
        {
            //play hit animation hitFX
            hitPoints = hitPoints - 5f;
            print("object hit");
        }
    }
}
