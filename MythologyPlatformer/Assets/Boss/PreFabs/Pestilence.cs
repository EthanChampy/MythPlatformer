using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pestilence : MonoBehaviour {

    public int PestHealth = 20;

    Rigidbody2D PestRB;

    public GameObject War;
    GameObject Player;

    public float MoveSpeed = 1.2f;
    public float TimeMoving = 5;

    public float TimeCount = 0;

    private bool ScaleState = false;

    private Vector3 PositiveScale = new Vector3(1, 1, 1);
    private Vector3 NegativeScale = new Vector3(-1, 1, 1);

    public bool Invincible;

    SpriteRenderer ThisSR;
    // Use this for initialization
    void Start()
    {
        ThisSR = GetComponent<SpriteRenderer>();
        PestRB = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        TimeCount += Time.deltaTime;

        PestRB.velocity = new Vector2(MoveSpeed * transform.localScale.x, PestRB.velocity.y);

        if (TimeCount >= TimeMoving && ScaleState == false)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            TimeCount = 0;
            ScaleState = true;
        }

        if (TimeCount >= TimeMoving && ScaleState == true)
        {
            this.gameObject.transform.localScale = PositiveScale;
            TimeCount = 0;
            ScaleState = false;
        }

        if (PestHealth <= 0)
        {
            Instantiate(War, new Vector3(-3.19f, -2.336f, 0), Quaternion.identity);
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
