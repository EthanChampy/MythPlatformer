using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineRise : MonoBehaviour {

    Rigidbody2D VineRB;

    public float MoveSpeed = 1.2f;
    public float TimeMoving = 5;

    public float TimeCount = 0;

    public bool ScaleState;

    // Use this for initialization
    void Start () {
        TimeCount = 0;
        VineRB = GetComponent<Rigidbody2D>();
        if (this.gameObject.name == ("Vine1(Clone)"))
        {
            ScaleState = false;
        }
        if (this.gameObject.name == ("Vine2(Clone)"))
        {
            ScaleState = true;
        }
    }
	
	// Update is called once per frame
	void Update () //Move vines up and down
    {
        TimeCount += Time.deltaTime;

        if (GameObject.Find("PestBoss(Clone)") != null)
        {
            if (TimeCount < TimeMoving && ScaleState == false)
            {
                VineRB.velocity = new Vector2(VineRB.velocity.x, MoveSpeed * transform.localScale.y);
            }

            if (TimeCount < TimeMoving && ScaleState == true)
            {
                VineRB.velocity = new Vector2(VineRB.velocity.x, -MoveSpeed * transform.localScale.y);
            }

            if (TimeCount >= TimeMoving && ScaleState == false)
            {
                TimeCount = 0;
                ScaleState = true;
            }

            if (TimeCount >= TimeMoving && ScaleState == true)
            {
                TimeCount = 0;
                ScaleState = false;
            }
        }

        else //Vine Destroyed
        {
            Destroy(this.gameObject);
        }
    }
}
