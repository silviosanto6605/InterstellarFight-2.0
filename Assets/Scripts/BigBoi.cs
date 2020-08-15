﻿using UnityEngine;

public class BigBoi : MonoBehaviour
{


    public static Vector3 BossStartPosition = new Vector3(16.6f, 0, 0);

    private Animator anim;
    private bool startanimplayed = false;
    private readonly bool CanFire = true;
    public GameObject MissilePrefab;
    public GameObject FirePoint;



    private void Start()
    {

        anim = GetComponent<Animator>();
    }

    private void Update()
    {



        if (!startanimplayed)
        {

            //if animation is played destroy animator, in order to make the boss move
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {
                anim.StopPlayback();
                Invoke("Attack", 3);
                startanimplayed = true;

            }
        }

    }

    void Attack()
    {

        Instantiate(MissilePrefab, FirePoint.transform.position , Missile.MissileRotation );
        Invoke("Attack", UnityEngine.Random.Range(0, 5));

    }













}
