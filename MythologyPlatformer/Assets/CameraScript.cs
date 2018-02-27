using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    GameObject Player;
    GameObject Camera;

	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        Camera = this.gameObject;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Camera.transform.position = Player.transform.position + new Vector3(0, 0, -10);
    }
}
