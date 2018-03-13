using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobBehaviour : MonoBehaviour {


    public bool Invincible = false;
    public int BlobHealth = 10;

    GameObject Player;

    SpriteRenderer ThisSR;

    void Start()
    {
        ThisSR = GetComponent<SpriteRenderer>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
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

    void ColorOn()
    {
        ThisSR.color = new Color(ThisSR.color.r, ThisSR.color.g, ThisSR.color.b, 255);
    }

    void ColorOff()
    {
        ThisSR.color = new Color(ThisSR.color.r, ThisSR.color.g, ThisSR.color.b, 0);
    }
}
