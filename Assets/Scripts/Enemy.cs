using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static float EnemySpeed = 3;
    private Rigidbody2D rb;
    private Animator anim;
    public static bool isEnemyDead;
    //private bool startanimplayed = false;

    void Start()
    {
        isEnemyDead = false;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    private void Update()
    {




        if (rb != null)
        {
            rb.velocity = new Vector2(-1 * EnemySpeed, 0);
        }

    }
    //Check if Enemy is colliding with something
    private void OnCollisionEnter2D(Collision2D collision)
    {

        //Check if Enemy is colliding with another Enemy instance 
        if (collision.gameObject.tag == "Enemy")
        {

            float RandX = Random.Range(3, 12);
            float RandY = Random.Range(-4, 6);
            Vector2 whereToSpawn = new Vector2(RandX, RandY);
            transform.position = whereToSpawn;

        }

        //Check if Enemy have reached base
        if (collision.gameObject.name == "Base")
        {
            Destroy(gameObject);
            Health.HealthLoss();

        }
        if (collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
            Health.HealthLoss();

        }

    }

}