using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosqZombieBehaviour : MonoBehaviour {

    public int ZombieHealth = 10;
    public int ZombieDmg = 2;

    public float MoveSpeed = 1.2f;
    public float TimeMoving = 5;

    public float TimeCount = 0;

    private bool ScaleState = false;

    private Vector3 PositiveScale = new Vector3(1,1,1);
    private Vector3 NegativeScale = new Vector3(-1, 1, 1);
    Rigidbody2D ZombRB;

    GameObject Player;
    public GameObject Mosquito;
    
    public bool Invincible;
    // Use this for initialization
    void Start ()
    {
        ZombRB = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        TimeCount += Time.deltaTime;

        ZombRB.velocity = new Vector2(MoveSpeed * transform.localScale.x, ZombRB.velocity.y);

        if (TimeCount >= TimeMoving && ScaleState == false)
        {
                transform.localScale = new Vector3(-1, 1, 1);
                TimeCount = 0;
            ScaleState = true;
        }

        if (TimeCount >= TimeMoving && ScaleState == true)
        {
                this.gameObject.transform.localScale = PositiveScale;
                TimeCount = 0;
            ScaleState = false;
        }

        if (ZombieHealth <= 0)
        {
            Instantiate(Mosquito, transform.position + new Vector3(0,0.2f,0), Quaternion.identity);
            Destroy (this.gameObject);
        }
    }

    void invincibleTimer()
    {
        Invincible = false;
    }

}
