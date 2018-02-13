using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private bool Attacking = false;

    private float AttackCurrCooldown;
    private float AttackMaxCooldown = 0.3f;

    public Collider2D AttackHitbox;

	void Awake () {
        AttackHitbox.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("p") && !Attacking)
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
