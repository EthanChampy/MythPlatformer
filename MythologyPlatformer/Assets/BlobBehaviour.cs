using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobBehaviour : MonoBehaviour {


    public bool Invincible = false;
    public int BlobHealth = 10;

    GameObject Player;

    void Start()
    {
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
}
