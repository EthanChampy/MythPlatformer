using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPoint : MonoBehaviour {

    GameObject AttackHitbox;

	// Use this for initialization
	void Start () {
        AttackHitbox = GameObject.Find("AttackHitbox");
	}
	
	// Update is called once per frame
	void Update () {
        Physics2D.IgnoreCollision(AttackHitbox.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
