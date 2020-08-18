using UnityEngine;

public class Weapon : MonoBehaviour
{
    public static int bullet_shooted;
    public static int maxbulletallowed = 25 ;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject FireRateLimitAlert;
    private readonly int cooldowntime = 7;
    private bool CanFire = true;


    private void Start()
    {
        InvokeRepeating("Reload", 1, cooldowntime);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            bullet_shooted = maxbulletallowed;
            Invoke("Reload",3);

        }
        
        
        if (CanFire)
        {
            FireRateLimitAlert.SetActive(false);
            if (Input.GetButtonDown("Fire1")) Shoot();
        }
        else
        {
            FireRateLimitAlert.SetActive(true);
        }

        StopFiring();
    }

    private void Shoot()
    {
        if (!UIController.GameIsPaused) {
            GetComponent<AudioSource>().Play();
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet_shooted += 1;
        }
    }

    void Reload()
    {
        if (!CanFire)
        {
            bullet_shooted = 0;
            CoolDownUI.slider.value = 0;
            CanFire = true;
        }
    }

    private void StopFiring()
    {
        if (bullet_shooted >= maxbulletallowed) CanFire = false;
    }
}