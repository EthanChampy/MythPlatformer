using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

    public Text text;
    GameObject Player;

	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (text.name == "HealthDisplay")
        {
            text.text = "" + Player.GetComponent<Player>().Health;
        }

        if (text.name == "ArmorDisplay")
        {
            text.text = "" + Player.GetComponent<Player>().Armor;
        }
    }
}
