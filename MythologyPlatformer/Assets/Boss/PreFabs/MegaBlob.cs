using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaBlob : MonoBehaviour {

    public bool Invincible = false;
    public int BlobHealth = 10;

    public float TimeCount;
    public float TimeMoving;
    public float MoveSpeed;

    Rigidbody2D BlobRB;

    GameObject Player;

    void Start()
    {
        BlobRB = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (GameObject.Find("FamineBoss(Clone)") != null)
        {
            TimeCount += Time.deltaTime;

            if (TimeCount < TimeMoving)
            {
                BlobRB.velocity = new Vector2(BlobRB.velocity.x, -MoveSpeed * transform.localScale.y);
            }

            if (TimeCount >= TimeMoving)
            {
                BlobRB.velocity = new Vector2(0, 0);
            }
        }

        if (BlobHealth <= 0)
        {
            Player.GetComponent<Player>().Armor += 1;
            Destroy(this.gameObject);
        }
    }

    void invincibleTimer()
    {
        Invincible = false;
    }
}
