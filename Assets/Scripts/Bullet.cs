using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    private void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);
            Enemy.isEnemyDead = true;
            collision.GetComponent<Animator>().SetBool("isDead", true);
            DestroyMovingAndAnimatedObject(collision);
            var AS = collision.GetComponent<AudioSource>();
            AS.Play();
            Score.score += 10;
            Destroy(collision.gameObject, AS.clip.length + 1);
        }


        else if (collision.name == "OutOfScene")
        {
            Destroy(gameObject);
        }

        else if (collision.tag == "Bomb")
        {
            
            collision.GetComponent<Animator>().SetBool("TimerEnded", true);
            DestroyMovingAndAnimatedObject(collision);
            Destroy(gameObject);

        }

        else if (collision.tag == "Missile")
        {
            collision.GetComponent<Animator>().SetBool("isDestroyed", true);
            DestroyMovingAndAnimatedObject(collision);
            Destroy(gameObject);
        }


        else if (collision.tag == "Boss1")
        {
            Destroy(gameObject);
            Boss1.BossHealth -= 10;
        }
    }

    public void DestroyMovingAndAnimatedObject(Collider2D collision)
    {
        Destroy(collision.GetComponent<Collider2D>());
        Destroy(collision.GetComponent<Rigidbody2D>());
        Destroy(collision.gameObject, collision.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + 0.5f);
        
    }
}