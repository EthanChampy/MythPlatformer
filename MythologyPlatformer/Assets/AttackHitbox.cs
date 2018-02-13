using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Rigidbody2D EnemyRigidBody = other.gameObject.GetComponent<Rigidbody2D>();
        }
    }
}
