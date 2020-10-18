using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerScript : MonoBehaviour
{
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, Random.Range(3f, 5f));
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    private void SpawnEnemy()
    {
        Instantiate(enemy, getRandomPositionForEnemySpawn(), Quaternion.identity);
    }

    private Vector3 getRandomPositionForEnemySpawn()
    {
        Vector3 result = new Vector3();
        var randomXCoordinate = Random.Range(0.7f, 1f);
        var randomYCoordinate = Random.Range(0.0f, 1f);
        result.Set(
            randomXCoordinate,
            randomYCoordinate,
            0);
        return result;
    }
}
