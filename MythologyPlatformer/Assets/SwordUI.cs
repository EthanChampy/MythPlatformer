using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordUI : MonoBehaviour {

    GameObject AttackHitbox;

	// Use this for initialization
	void Start ()
    {
        AttackHitbox = GameObject.Find("AttackHitbox");
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (AttackHitbox.GetComponent<AttackHitbox>().DamageMult == 1)
        {
            GetComponent<Image>().enabled = false;
        }

        if (AttackHitbox.GetComponent<AttackHitbox>().DamageMult == 2)
        {
            GetComponent<Image>().enabled = true;
        }
    }
}
