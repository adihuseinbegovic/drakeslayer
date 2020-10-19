using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public int hp = 3;
    public bool isEnemy = true;
    private GameObject healthNumberTextObject;


    /// <summary>
    /// Inflicts damage and check if the object should be destroyed
    /// </summary>
    /// <param name="damageCount"></param>
    public void Damage(int damageCount)
    {
        hp -= damageCount;

        if (hp <= 0)
        {
            // Dead!
            Destroy(gameObject);

            // if is enemy killed -> increase the score counter
            if (isEnemy)
            {
                CommonUtils.IncreaseScore(1000);
            } 
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Is this a shot?
        ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            // Avoid friendly fire
            if (shot.isEnemyShot != isEnemy)
            {
                Damage(shot.damage);

                if (shot.isEnemyShot)
                {
                    SetPlayerHealthText();
                }

                // Destroy the shot
                Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
            }
        }
    }

    public void SetPlayerHealthText()
    {

        if (healthNumberTextObject == null)
        {
            healthNumberTextObject = GameObject.FindGameObjectWithTag("HealthNumberText");
        }

        if (healthNumberTextObject != null)
        {
            var healthText = healthNumberTextObject.GetComponent<Text>();
            healthText.text = hp.ToString();
        }
    }
}
