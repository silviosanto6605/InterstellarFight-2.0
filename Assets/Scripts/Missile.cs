using UnityEngine;

public class Missile : MonoBehaviour
{
    public static Quaternion MissileRotation = new Quaternion(0, 0, 90, 0);
    public float speed = -5f;
    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Explode();
            Health.HealthLoss();
        }

        else if (collision.gameObject.tag == "Border")
        {
            Explode();
            Health.HealthLoss();
        }
    }

    public void Explode()
    {
        GetComponent<Animator>().SetBool("isDestroyed", true);
        Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + 0f);
        Destroy(gameObject);
    }
}