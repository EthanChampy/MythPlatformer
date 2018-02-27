using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorBehaviour : MonoBehaviour {

    public int WarriorHealth = 20;
    public int WarriorDmg = 3;

    public float MoveSpeed = 1f;
    public float TimeMoving = 5;

    public float TimeCount = 0;

    private bool ScaleState = false;

    private Vector3 PositiveScale = new Vector3(1, 1, 1);
    private Vector3 NegativeScale = new Vector3(-1, 1, 1);
    Rigidbody2D WarriorRB;

    public bool Invincible;

    // Use this for initialization
    void Start () {
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
            Destroy(this.gameObject);
        }
    }

    void invincibleTimer()
    {
        Invincible = false;
    }
}
