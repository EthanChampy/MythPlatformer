using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoBehaviour : MonoBehaviour {

    private int MosquitoHealth = 14;
    private int OnHostDamage = 2;
    private int OffHostDamage = 4;
    private int NeedleDamage = 1;

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
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update ()
    {
        TimeCount += Time.deltaTime*speed;

        float NEWx = Mathf.Cos(TimeCount)*width + spawnx;
        float NEWy = Mathf.Sin(TimeCount)*height + spawny;

        transform.position = new Vector2(NEWx, NEWy);

	}
}
