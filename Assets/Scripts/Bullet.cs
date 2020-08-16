using UnityEngine;


public class Bullet : MonoBehaviour {
    public float speed = 20f;
    public Rigidbody2D rb;

    private void Start () {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D (Collider2D collision) {


        /*if collide with enemy, destroy enemy, destroy rigidbody and collider, play animation and audio, increase 
        score and destroy gameobject after animation ending*/

        if (collision.tag == "Enemy")
        {

            Destroy(gameObject);
            Enemy.isEnemyDead = true;
            collision.GetComponent<Animator>().SetBool("isDead", true);
            Destroy(collision.GetComponent<Collider2D>());
            Destroy(collision.GetComponent<Rigidbody2D>());
            Destroy(collision.gameObject, collision.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + 0f);
            AudioSource AS = collision.GetComponent<AudioSource>();
            AS.Play();
            Score.score += 10;
            Destroy(collision.gameObject, AS.clip.length + 1);

        }


        else if (collision.name == "OutOfScene")
        {
            Destroy(gameObject);
        }

        else if (collision.tag == "Missile")
        {

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        else if (collision.tag == "Boss1")
        {
            Destroy(gameObject);
            /* reduce boss health*/
        }



    }

}
