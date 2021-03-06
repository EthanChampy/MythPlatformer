﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeleMelee : MonoBehaviour {

    public int SkeleHealth = 10;

    public float AttackTimer = 1.6f;
    public float CountUp = 0;

    public Collider2D SkeleHitbox;

    public bool Invincible = false;

    SpriteRenderer ThisSR;

    void Start()
    {
        ThisSR = GetComponent<SpriteRenderer>();
    }

        // Update is called once per frame
        void Update ()
    {
        CountUp += Time.deltaTime;

        if (CountUp <= 0.7f && 0.6f <= CountUp)
        {
            SkeleHitbox.enabled = true;
        }
        else
        {
            SkeleHitbox.enabled = false;
        }

        if (CountUp >= AttackTimer)
        {
            CountUp = 0f;
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

    void ColorOn()
    {
        ThisSR.color = new Color(ThisSR.color.r, ThisSR.color.g, ThisSR.color.b, 255);
    }

    void ColorOff()
    {
        ThisSR.color = new Color(ThisSR.color.r, ThisSR.color.g, ThisSR.color.b, 0);
    }
}
