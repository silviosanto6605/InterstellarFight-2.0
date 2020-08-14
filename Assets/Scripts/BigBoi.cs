using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BigBoi : MonoBehaviour
{


    public static Vector3 BossStartPosition = new Vector3(16.6f,0,0);

    private Animator anim;
    private bool startanimplayed = false;

    private void Start(){

        anim = GetComponent<Animator>();
    }

    private void Update()
    {

        

        if (!startanimplayed) {

            //if animation is played destroy animator, in order to make the boss move
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1) {
                Destroy(anim);
                Invoke("Attack", 3);
                startanimplayed = true;

            }
        }

    }

    void Attack()
    {
        Debug.Log("attacco");
        Invoke("Attack", UnityEngine.Random.Range(1,5));

    }


  










}
