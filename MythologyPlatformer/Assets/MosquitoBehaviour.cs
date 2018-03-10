using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoBehaviour : MonoBehaviour {

    public int MosquitoHealth = 14;
    private int NeedleDamage = 1;

    public bool Invincible = false;

    public Collider2D Sensor;

    private float TimeCount;
    public float speed;
    public float width;
    public float height;

    public float spawnx;
    public float spawny;

    GameObject Player;
    void Start()
    {
        spawnx = transform.position.x;
        spawny = transform.position.y;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update ()
    {
        TimeCount += Time.deltaTime*speed;

        float NEWx = Mathf.Cos(TimeCount)*width + spawnx;
        float NEWy = Mathf.Sin(TimeCount)*height + spawny;

        transform.position = new Vector2(NEWx, NEWy);

        if (MosquitoHealth <= 0)
        {
            Player.GetComponent<Player>().Armor += 1;
            Destroy (this.gameObject);
        }
	}

    void invincibleTimer()
    {
        Invincible = false;
    }
}
