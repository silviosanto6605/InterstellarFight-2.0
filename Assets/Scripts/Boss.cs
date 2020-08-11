using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{


    public static Vector3 BossStartPosition = new Vector3(16.6f,0,0);
    private Rigidbody2D rb;
    private int bossspeed = 10;

    private void Start(){


        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bossspeed;

    }







}
