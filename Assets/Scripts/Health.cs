using UnityEngine;

public class Health : MonoBehaviour
{
    public static GameObject GameInterface;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;


    //Set healthbar to full
    private void Start()
    {
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
    }

    private void Update()
    {
        //Health check
        /*if (Player.health > 3)
            Player.health = 3;*/

        switch (Player.health)
        {
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;

            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;

            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;

            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;
        }
    }

    //Play health loss animation
    public static void HealthLoss()
    {
        Player.health -= 1;
        var GameInterface = GameObject.Find("GameInterface").gameObject;
        GameInterface.GetComponent<Animation>().Play();
    }
}