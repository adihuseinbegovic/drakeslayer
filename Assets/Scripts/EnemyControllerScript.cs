using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerScript : MonoBehaviour
{
    public GameObject enemy;
    private int stage = 0;

    // Start is called before the first frame update
    void Start()
    {
        stage = 0;
        InvokeRepeating("SpawnEnemy", 0f, Random.Range(5f, 9f));
    }

    // Update is called once per frame
    void Update()
    {
        int score = CommonUtils.getScore();
        switch (score)
        {
            case int _ when score > 5000:
                if (stage == 0)
                {
                    stage = 1;
                    CancelInvoke();
                    InvokeRepeating(nameof(SpawnEnemy), 0f, 3);
                }
                break;
            case int _ when score > 10000:
                if (stage == 1)
                {
                    stage = 2;
                    CancelInvoke();
                    InvokeRepeating(nameof(SpawnEnemy), 0f, 2);
                }
                break;
            case int _ when score > 20000:
                if (stage == 2)
                {
                    stage = 3;
                    CancelInvoke();
                    InvokeRepeating(nameof(SpawnEnemy), 0f, 1);
                }
                break;
            case int _ when score > 50000:
                if (stage == 3)
                {
                    stage = 4;
                    CancelInvoke();
                    InvokeRepeating(nameof(SpawnEnemy), 0f, 0.5f);
                }
                break;
            default:
                break;
        }
    }


    private void SpawnEnemy()
    {
        if (stage >= 3)
        {
            Instantiate(enemy, getRandomPositionForEnemySpawn(), Quaternion.identity);
        }
        Instantiate(enemy, getRandomPositionForEnemySpawn(), Quaternion.identity);
    }

    private Vector3 getRandomPositionForEnemySpawn()
    {
        float enemyHeight = enemy.GetComponent<Renderer>().bounds.size.y;
        return Camera.main.ScreenToWorldPoint(
            new Vector3(
                //Random.Range(Screen.width - Screen.width/4, Screen.width), // last 1/4th of the camera
                Random.Range(Screen.width, Screen.width + Screen.width / 5),
                Random.Range(0 + enemyHeight, Screen.height - enemyHeight),
                Camera.main.farClipPlane / 2));
    }
}
