using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject FireRateLimitAlert;
    private bool CanFire = true;
    public static int bullet_shooted = 0;
    private int cooldowntime = 7;
    private int maxbulletallowed = 15;


    private void Start()
    {

        InvokeRepeating("ClearLimit", 1, cooldowntime);

    }

    void Update()
    {


        if (CanFire)
        {
            FireRateLimitAlert.SetActive(false);
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            FireRateLimitAlert.SetActive(true);

        }

        StopFiring();

    }

    void Shoot()
    {
        if (!UIController.GameIsPaused) {

            GetComponent<AudioSource>().Play();
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet_shooted += 1;
        }


    }

    private void ClearLimit()
    {
        if (!CanFire) {

            bullet_shooted = 0;
            CoolDownUI.slider.value = 0;
            CanFire = true;

        }




    }

    private void StopFiring()
    {


        if (bullet_shooted > maxbulletallowed)
        {

            CanFire = false;

        }

    }

}