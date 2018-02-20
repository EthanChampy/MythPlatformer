using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour {

    public int SwordDamage = 2;
    public int DamageMult = 1;

    GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Mosquito" && other.gameObject.GetComponent<MosquitoBehaviour>().Invincible == false)
        {
            other.gameObject.GetComponent<MosquitoBehaviour>().MosquitoHealth += -(SwordDamage * DamageMult * 2);
            other.gameObject.GetComponent<MosquitoBehaviour>().Invincible = true;
            other.gameObject.GetComponent<MosquitoBehaviour>().Invoke("invincibleTimer", 1);
        }

        if (other.gameObject.tag == "MosqZomb" && other.gameObject.GetComponent<MosqZombieBehaviour>().Invincible == false)
        {
            other.gameObject.GetComponent<MosqZombieBehaviour>().ZombieHealth += -(SwordDamage * DamageMult);
            other.gameObject.GetComponent<MosqZombieBehaviour>().Invincible = true;
            other.gameObject.GetComponent<MosqZombieBehaviour>().Invoke("invincibleTimer", 1);
        }

        if (other.gameObject.tag == "Warrior" && other.gameObject.GetComponent<WarriorBehaviour>().Invincible == false && Player.transform.localScale.x == other.gameObject.transform.localScale.x)
        {
            other.gameObject.GetComponent<WarriorBehaviour>().WarriorHealth += -(SwordDamage * DamageMult);
            other.gameObject.GetComponent<WarriorBehaviour>().Invincible = true;
            other.gameObject.GetComponent<WarriorBehaviour>().Invoke("invincibleTimer", 1);
        }
    }
}
