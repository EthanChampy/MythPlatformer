using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorBehaviour : MonoBehaviour {

    public int WarriorHealth = 30;

    public float MoveSpeed = 1f;
    public float TimeMoving = 5;

    public float TimeCount = 0;

    private bool ScaleState = false;

    private Vector3 PositiveScale = new Vector3(1, 1, 1);
    private Vector3 NegativeScale = new Vector3(-1, 1, 1);
    Rigidbody2D WarriorRB;

    GameObject Player;
    public bool Invincible;
    
    SpriteRenderer ThisSR;

    void Start()
    {
        ThisSR = GetComponent<SpriteRenderer>();
        Player = GameObject.FindGameObjectWithTag("Player");
        WarriorRB = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        TimeCount += Time.deltaTime;

        WarriorRB.velocity = new Vector2(MoveSpeed * transform.localScale.x, WarriorRB.velocity.y);

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

        if(WarriorHealth <= 0)
        {
            Player.GetComponent<Player>().Armor += 1;
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
