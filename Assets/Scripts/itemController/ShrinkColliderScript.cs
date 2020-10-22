using UnityEngine;

public class ShrinkColliderScript : MonoBehaviour
{
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
