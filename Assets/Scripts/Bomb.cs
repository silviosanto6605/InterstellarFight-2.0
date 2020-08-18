using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // ReSharper disable  Unity.PerformanceCriticalCodeInvocation

    private Transform target;
    private readonly float speed = 3f;
    private readonly float rotateSpeed = 200f;
    private Animation explosion;
    private Animator anim;
    private Rigidbody2D rb;
    private readonly float timer = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<Player>().GetComponent<Transform>();
        explosion = GetComponent<Animation>();
        anim = GetComponent<Animator>();
        StartCoroutine(Timer());
    }

    private void FixedUpdate()
    {
        if (GetComponent<Rigidbody2D>() != null)
        {
            var direction = (Vector2) target.position - rb.position;

            direction.Normalize();

            var rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = transform.up * speed;
        }
    }

    private void OnCollisionEnter2D()
    {
        explode();
        Health.HealthLoss();
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(timer);
        explode();
    }

    private void explode()
    {
        gameObject.GetComponent<Animator>().SetBool("TimerEnded", true);
        Destroy(gameObject.GetComponent<CircleCollider2D>());
        Destroy(gameObject.GetComponent<Rigidbody2D>());
        Destroy(gameObject, anim.GetCurrentAnimatorStateInfo(0).length + 0f);
    }
}