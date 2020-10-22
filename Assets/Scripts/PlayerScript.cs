using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public Vector2 speed = new Vector2(5, 5);
    private Vector2 movement;
    private Rigidbody2D rigidbodyComponent;
    public bool hasShrink;
    private bool alreadyShrunk;

    void Update()
    {
        // 3 - Retrieve axis information
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        // 4 - Movement per direction
        movement = new Vector2(
          speed.x * inputX,
          speed.y * inputY);

        // 5 - Shooting
        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");

        if (shoot)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
                // false because the player is not an enemy
                weapon.Attack(false);
            }
        }

        // here we check input for the shrink and execute it
        CheckActivateShrink();

        OutsideOfCamera();

        // count the score with a +1
        CommonUtils.IncreaseScore(1);

    }

    // check if the user activated shrink
    private void CheckActivateShrink()
    {
        bool inputC = Input.GetButtonDown("Shrink");

        if (inputC && hasShrink && !alreadyShrunk)
        {
            gameObject.transform.localScale = gameObject.transform.localScale / 2;
            alreadyShrunk = true;
            hasShrink = false;
            Invoke(nameof(ReturnToNormalSize), 5);
        }
    }

    // return the player to the normal size
    private void ReturnToNormalSize()
    {
        if (alreadyShrunk)
        {
            gameObject.transform.localScale = gameObject.transform.localScale * 2;
            alreadyShrunk = false;
        }
    }

    void FixedUpdate()
    {
        if (rigidbodyComponent == null)
        {
            rigidbodyComponent = GetComponent<Rigidbody2D>();
        }

        rigidbodyComponent.velocity = movement;
    }

    // not outside the camera
    private void OutsideOfCamera()
    {
        var dist = (transform.position - Camera.main.transform.position).z;
        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;

        transform.position = new Vector3(
          Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
          Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
          transform.position.z
        );
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool damagePlayer = true;

        // Collision with enemy
        EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            // Kill the enemy
            HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
            if (enemyHealth != null) enemyHealth.Damage(enemyHealth.hp);

            damagePlayer = true;
        }

        // Damage the player
        if (damagePlayer)
        {
            HealthScript playerHealth = this.GetComponent<HealthScript>();
            if (playerHealth != null)
            {
                playerHealth.Damage(1);
                playerHealth.SetPlayerHealthText();
            }
        }
    }

    void OnDestroy()
    {
        var gameOver = FindObjectOfType<GameOverScript>();
        if (gameOver != null)
        {
            gameOver.ShowButtons();
        }
    }

    private void Start()
    {
        hasShrink = false;
        alreadyShrunk = false;

        HealthScript playerHealth = this.GetComponent<HealthScript>();
        if (playerHealth != null)
        {
            playerHealth.SetPlayerHealthText();
        }
    }
}
