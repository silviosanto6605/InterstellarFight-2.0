using UnityEngine;

public class Weapon : MonoBehaviour {
    public Transform firePoint;
    public GameObject bulletPrefab;

    void Update () {
        if (Input.GetButtonDown("Fire1")) { Shoot (); }

    }

    void Shoot () {

        GetComponent<AudioSource> ().Play ();
        Instantiate (bulletPrefab, firePoint.position, firePoint.rotation);

    }
}