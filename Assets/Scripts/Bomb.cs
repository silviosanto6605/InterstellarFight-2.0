using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    
    // ReSharper disable  Unity.PerformanceCriticalCodeInvocation

    public Transform target;

    private float speed = 3f;
    private float rotateSpeed = 200f;
    private Animation explosion;
    private Animator anim;
    private Rigidbody2D rb;
    private float timer = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<Player>().GetComponent<Transform>();
        explosion = GetComponent<Animation>();
        anim = GetComponent<Animator>();
        StartCoroutine(Timer());
    }

    void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = transform.up * speed;
    }

    void OnCollisionEnter2D()
    {
        explode();
       
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(timer);
        explode();

    }

    void explode()
    {
        GetComponent<Animator>().SetBool("TimerEnded", true);
        Destroy(GetComponent<CircleCollider2D>());
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(gameObject, anim.GetCurrentAnimatorStateInfo(0).length + 0f);
    }



}
