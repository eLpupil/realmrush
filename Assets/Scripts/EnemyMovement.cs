using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Range(0.1f, 5f)] [SerializeField] float movementPeriod = 2f;

    [SerializeField] ParticleSystem explosionPrefab;


    // Start is called before the first frame update
    void Start()
    {
        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        var path = pathFinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {

        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(movementPeriod);
        }

        DestroyEnemy();
        FindObjectOfType<BaseHealth>().StartEnemyContactSequence();
    }

    private void DestroyEnemy()
    {
        ParticleSystem deathFX = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        float delay = deathFX.main.duration;

        deathFX.Play();
        Destroy(deathFX.gameObject, delay);
        Destroy(gameObject);
    }
}
