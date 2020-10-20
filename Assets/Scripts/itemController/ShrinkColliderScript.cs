using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkColliderScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // onTrigger for player and the shrink item
        PlayerScript player = otherCollider.gameObject.GetComponent<PlayerScript>();
        if (player != null)
        {
            player.hasShrink = true;
            Destroy(gameObject);
        }
    }
}
