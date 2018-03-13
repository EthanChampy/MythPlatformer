using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class War : MonoBehaviour {

    public int WarHealth = 20;

    Rigidbody2D WarRB;


    public GameObject Famine;
    public GameObject Blob;

    GameObject BossFight;

    GameObject Player;

    public float MoveSpeed = 1.2f;
    public float TimeMovingPart1 = 5;
    public float TimeMovingPart2 = 5;
    public float TimeMovingPart3 = 5;

    public float TimeCount = 0;

    public bool idle;

    private bool ScaleState = false;

    private Vector3 PositiveScale = new Vector3(1, 1, 1);
    private Vector3 NegativeScale = new Vector3(-1, 1, 1);

    int AttackPart;

    public bool Invincible;
    SpriteRenderer ThisSR;

    void Start()
    {
        ThisSR = GetComponent<SpriteRenderer>();
        AttackPart = 1;
        WarRB = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        BossFight = GameObject.Find("BossFight");
    }

    // Update is called once per frame
    void Update()
    {
        TimeCount += Time.deltaTime;

        if (AttackPart == 1)
        {
            WarRB.velocity = new Vector2(MoveSpeed * transform.localScale.x, WarRB.velocity.y);

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
            WarRB.velocity = new Vector2(MoveSpeed * transform.localScale.x, WarRB.velocity.y);

            if (TimeCount >= TimeMovingPart2 && ScaleState == true)
            {
                TimeCount = 0;
                idle = true;
                AttackPart = 3;
            }
        }

        if (AttackPart == 3)
        {
            WarRB.velocity = new Vector2(0, 0);

            if (TimeCount >= TimeMovingPart3 && ScaleState == true)
            {
                transform.localScale = new Vector3(1, 1, 1);
                TimeCount = 0;
                ScaleState = false;
                idle = false;
                AttackPart = 4;
            }
        }

        if (AttackPart == 4)
        {
            {
                WarRB.velocity = new Vector2(MoveSpeed * transform.localScale.x, WarRB.velocity.y);

                if (TimeCount >= TimeMovingPart2 && ScaleState == false)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    TimeCount = 0;
                    ScaleState = true;
                    AttackPart = 5;
                    this.gameObject.transform.position = new Vector3(2.02f, -2.336f, 0);
                }
            }
        }

        if (AttackPart == 5)
        {
            WarRB.velocity = new Vector2(MoveSpeed * transform.localScale.x, WarRB.velocity.y);

            if (TimeCount >= TimeMovingPart1 && ScaleState == true)
            {
                transform.localScale = new Vector3(1, 1, 1);
                TimeCount = 0;
                ScaleState = true;
                AttackPart = 6;
                this.gameObject.transform.position = new Vector3(-3.207f, -1.699f, 0);
            }
        }

        if (AttackPart == 6)
        {
            WarRB.velocity = new Vector2(MoveSpeed * transform.localScale.x, WarRB.velocity.y);

            if (TimeCount >= TimeMovingPart2 && ScaleState == true)
            {
                TimeCount = 0;
                idle = true;
                AttackPart = 7;
            }
        }

        if (AttackPart == 7)
        {
            WarRB.velocity = new Vector2(0, 0);

            if (TimeCount >= TimeMovingPart3 && ScaleState == true)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                TimeCount = 0;
                ScaleState = false;
                idle = false;
                AttackPart = 8;
            }
        }

        if (AttackPart == 8)
        {
            WarRB.velocity = new Vector2(MoveSpeed * transform.localScale.x, WarRB.velocity.y);

            if (TimeCount >= TimeMovingPart2 && ScaleState == false)
            {
                transform.localScale = new Vector3(1, 1, 1);
                TimeCount = 0;
                ScaleState = false;
                AttackPart = 1;
                this.gameObject.transform.position = new Vector3(-3.19f, -2.336f, 0);
            }
        }

        if (WarHealth <= 0)
        {
            Instantiate(Famine, new Vector3(-3.19f, -2.336f, 0), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    void invincibleTimer()
    {
        Invincible = false;
    }

    void ColorOn()
    {
        ThisSR.color = new Color(ThisSR.color.r, ThisSR.color.g, ThisSR.color.b, 255);
    }

    void ColorOff()
    {
        ThisSR.color = new Color(ThisSR.color.r, ThisSR.color.g, ThisSR.color.b, 0);
    }
}