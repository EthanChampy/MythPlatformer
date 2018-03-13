using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraScript : MonoBehaviour {

    GameObject Player;
    GameObject Camera;


    Camera CameraAddOn;


	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        Camera = this.gameObject;
        CameraAddOn = GetComponent<Camera>();
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (GameObject.Find("BossFight") != null)
        {
            Camera.transform.position = new Vector3(-0.59f, -1.51f, 0);
            CameraAddOn.orthographicSize = 1.235166f;
        }

        else
        {
            Camera.transform.position = Player.transform.position + new Vector3(0, 0.17f, -10);
            CameraAddOn.orthographicSize = 0.8793684f;
        }
    }
}
