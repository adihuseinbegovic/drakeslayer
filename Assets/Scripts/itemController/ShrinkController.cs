using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkController : MonoBehaviour
{

    public GameObject diamond;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnDiamond", 0f, 15f);
    }

    private void SpawnDiamond()
    {
        Instantiate(diamond, getRandomPositionForDiamondSpawn(), Quaternion.identity);
    }

    private Vector3 getRandomPositionForDiamondSpawn()
    {
        float diamondHeight = diamond.GetComponent<Renderer>().bounds.size.y;
        return Camera.main.ScreenToWorldPoint(
            new Vector3(
                Random.Range(Screen.width - Screen.width/4, Screen.width), // last 1/4th of the camera
                Random.Range(0 + diamondHeight, Screen.height - diamondHeight),
                Camera.main.farClipPlane / 2));
    }
}
