using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBehaviour : MonoBehaviour {

    public int SkeleHealth = 10;
    public int SkeleDmg = 2;

    public float MoveSpeed = 1.2f;
    public float TimeMoving = 5;

    public float TimeCount = 0;

    private bool ScaleState = false;
    private bool Attacking = false;

    private Vector3 PositiveScale = new Vector3(1, 1, 1);
    private Vector3 NegativeScale = new Vector3(-1, 1, 1);
    Rigidbody2D SkeleRB;

    GameObject Player;

    public bool Invincible;
    // Use this for initialization
    void Start()
    {
        SkeleRB = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Attacking == false)
        {
            TimeCount += Time.deltaTime;
        }

        SkeleRB.velocity = new Vector2(MoveSpeed * transform.localScale.x, SkeleRB.velocity.y);

        if (TimeCount >= TimeMoving && ScaleState == true && Attacking == false)
        {
            this.gameObject.transform.localScale = PositiveScale;
            TimeCount = 0;
            ScaleState = false;
        }

        if (TimeCount >= TimeMoving && ScaleState == false && Attacking == false)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            TimeCount = 0;
            ScaleState = true;
        }


        if (SkeleHealth <= 0)
        {            
            Destroy(this.gameObject);
        }
    }

    void invincibleTimer()
    {
        Invincible = false;
    }
}


