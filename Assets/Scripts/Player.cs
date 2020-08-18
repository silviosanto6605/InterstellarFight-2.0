using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D body;
    public static int health = 150;
    float vertical;
    float horizontal;
    public static bool PacmanEffect = true;
    public GameObject topborder;
    public GameObject botborder;
    public static float runSpeed;
    void Start()
    {
        runSpeed = 10f;
        body = GetComponent<Rigidbody2D>();
        /*Debug.Log(Screen.width.ToString() + "   " + Screen.height.ToString());*/
    }

    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        if (PacmanEffect)
        {


            topborder.GetComponent<BoxCollider2D>().enabled = false;
            botborder.GetComponent<BoxCollider2D>().enabled = false;

            if (gameObject.transform.position.y > 9)
            {
                transform.position -= new Vector3(0, 17.5f, 0);



            }
            else if (gameObject.transform.position.y < -8.2)
            {
                transform.position += new Vector3(0, 17.5f, 0);

            }

        }
        else if (!PacmanEffect)
        {

            topborder.GetComponent<BoxCollider2D>().enabled = true;
            botborder.GetComponent<BoxCollider2D>().enabled = true;

        }

    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(0 * runSpeed, vertical * runSpeed);

    }
}