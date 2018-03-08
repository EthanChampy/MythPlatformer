using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public bool Attacking = false;

    public float AttackCurrCooldown;
    public float AttackMaxCooldown = 0.9f;

    public Collider2D AttackHitbox;

    public GameObject Player;

	void Awake ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        AttackHitbox.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Player.GetComponent<Player>().DeathBool == false)
        {
            if (Input.GetButtonDown("Attack") && !Attacking)
            {
                Attacking = true;
                AttackCurrCooldown = AttackMaxCooldown;

                AttackHitbox.enabled = true;
            }

            if (Attacking)
            {
                if (AttackCurrCooldown > 0)
                {
                    AttackCurrCooldown -= Time.deltaTime;
                }
                else
                {
                    Attacking = false;
                    AttackHitbox.enabled = false;
                }
            }
        }
    }
}
