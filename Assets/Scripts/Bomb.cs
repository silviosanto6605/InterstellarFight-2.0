using UnityEngine;

public class Bomb : MonoBehaviour
{

    public Transform target;

    public float speed = 5f;
    public float rotateSpeed = 200f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<Player>().GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D()
    {
        /*Play explosion animation*/
        Destroy(gameObject);
        Health.HealthLoss();
    }
}
