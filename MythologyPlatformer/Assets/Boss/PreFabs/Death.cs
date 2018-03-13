using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

    public int DeathHealth = 10;

    Rigidbody2D DeathRB;

    GameObject BossFight;

    GameObject Player;

    public float SuperMoveSpeed = 20f;
    public float MoveSpeed = 1.2f;
    public float TimeMovingPart1 = 5;
    public float TimeMovingPart2 = 5;
    public float TimeMovingPart3 = 5;

    public float TimeCount = 0;

    private bool ScaleState = false;

    private Vector3 PositiveScale = new Vector3(1, 1, 1);
    private Vector3 NegativeScale = new Vector3(-1, 1, 1);

    int AttackPart;

    public bool Invincible;
    // Use this for initialization
    void Start()
    {
        AttackPart = 1;
        DeathRB = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        BossFight = GameObject.Find("BossFight");
    }

    // Update is called once per frame
    void Update()
    {
        TimeCount += Time.deltaTime;

        if (AttackPart == 1)
        {
            DeathRB.velocity = new Vector2(SuperMoveSpeed * transform.localScale.x, DeathRB.velocity.y);

            if (TimeCount >= TimeMovingPart1 && ScaleState == false)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                TimeCount = 0;
                ScaleState = true;
                AttackPart = 2;
                this.gameObject.transform.position = new Vector3(2.03f, -1.51f, 0);
            }
        }

        if (AttackPart == 2)
        {
            DeathRB.velocity = new Vector2(SuperMoveSpeed * transform.localScale.x, DeathRB.velocity.y);

            if (TimeCount >= TimeMovingPart1 && ScaleState == true)
            {
                transform.localScale = new Vector3(1, 1, 1);
                TimeCount = 0;
                ScaleState = false;
                AttackPart = 3;
                this.gameObject.transform.position = new Vector3(-3.288f, -0.4f, 0);
            }
        }

        if (AttackPart == 3)
        {
            DeathRB.velocity = new Vector2(SuperMoveSpeed * transform.localScale.x, DeathRB.velocity.y);

            if (TimeCount >= TimeMovingPart1 && ScaleState == false)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                TimeCount = 0;
                ScaleState = true;
                AttackPart = 4;
                this.gameObject.transform.position = new Vector3(2.03f, -1.05f, 0);
            }
        }

        if (AttackPart == 4)
        {
            DeathRB.velocity = new Vector2(SuperMoveSpeed * transform.localScale.x, DeathRB.velocity.y);

            if (TimeCount >= TimeMovingPart1 && ScaleState == true)
            {
                transform.localScale = new Vector3(1, 1, 1);
                TimeCount = 0;
                ScaleState = false;
                AttackPart = 5;
                this.gameObject.transform.position = new Vector3(-3.211f, -1.74f, 0);
            }
        }

        if (AttackPart == 5)
        {
            DeathRB.velocity = new Vector2(SuperMoveSpeed * transform.localScale.x, DeathRB.velocity.y);

            if (TimeCount >= TimeMovingPart1 && ScaleState == false)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                TimeCount = 0;
                ScaleState = true;
                AttackPart = 6;
                this.gameObject.transform.position = new Vector3(2.03f, -0.4f, 0);
            }
        }

        if (AttackPart == 6)
        {
            DeathRB.velocity = new Vector2(SuperMoveSpeed * transform.localScale.x, DeathRB.velocity.y);

            if (TimeCount >= TimeMovingPart1 && ScaleState == true)
            {
                transform.localScale = new Vector3(1, 1, 1);
                TimeCount = 0;
                ScaleState = false;
                AttackPart = 7;
                this.gameObject.transform.position = new Vector3(-3.288f, -2.33f, 0);
            }
        }

        if (AttackPart == 7)
        {
            DeathRB.velocity = new Vector2(MoveSpeed * transform.localScale.x, DeathRB.velocity.y);

            if (TimeCount >= TimeMovingPart2 && ScaleState == false)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                TimeCount = 0;
                ScaleState = true;
                AttackPart = 8;
                this.gameObject.transform.position = new Vector3(2.06f, -2.33f, 0);
            }
        }

        if (AttackPart == 8)
        {
            DeathRB.velocity = new Vector2(SuperMoveSpeed * transform.localScale.x, DeathRB.velocity.y);

            if (TimeCount >= TimeMovingPart1 && ScaleState == true)
            {
                transform.localScale = new Vector3(1, 1, 1);
                TimeCount = 0;
                ScaleState = false;
                AttackPart = 1;
                this.gameObject.transform.position = new Vector3(-3.288f, -2.33f, 0);
            }
        }

        if (DeathHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void invincibleTimer()
    {
        Invincible = false;
    }
}

