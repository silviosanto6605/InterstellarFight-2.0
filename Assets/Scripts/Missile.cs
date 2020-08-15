using UnityEngine;

public class Missile : MonoBehaviour
{

    public float speed = -20f;
    private Rigidbody2D rb;

    public static Quaternion MissileRotation = new Quaternion(0, 0, 90, 0);


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Health.HealthLoss();

        }


    }

}

