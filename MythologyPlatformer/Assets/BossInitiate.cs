using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInitiate : MonoBehaviour {

    public GameObject Vine1;
    public GameObject Vine2;
    public GameObject Pest;

	// Use this for initialization
	void Start ()
    {
        Instantiate(Pest, new Vector3(-1.559f, -2.329f, 0), Quaternion.identity);
        Invoke("VineSpawn", 0f);
    }

    void VineSpawn()
    {
        Instantiate(Vine1, new Vector3(-2.223f, -2.96f, 0), Quaternion.identity);
        Instantiate(Vine2, new Vector3(1.017f, -2.539f, 0), Quaternion.identity);
    }
}
