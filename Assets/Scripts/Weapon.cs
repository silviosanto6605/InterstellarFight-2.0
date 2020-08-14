using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject FireRateLimitText;
    private bool CanFire = true;
    private int bullet_shooted = 0;
    private int cooldowntime = 7;
    private int maxbulletallowed = 15;


    private void Start()
    {

        //Clear bullet fire ratio
        InvokeRepeating("ClearLimit", 1, cooldowntime);
    }

    void Update()
    {
        if (CanFire)
        {
            FireRateLimitText.SetActive(false);
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            FireRateLimitText.SetActive(true);

        }

        StopFiring();

    }

    void Shoot()
    {

        GetComponent<AudioSource>().Play();
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet_shooted += 1;

    }

    private void ClearLimit()
    {
        if (!CanFire) {

            bullet_shooted = 0;
            CanFire = true;
        }


    }

    private void StopFiring()
    {


        if (bullet_shooted > maxbulletallowed)
        {

            CanFire = false;
            Debug.Log("not allowed to do that");

        }

    }

}