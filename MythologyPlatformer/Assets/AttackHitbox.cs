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

    void Update()
    {
        if (Player.transform.localScale.x == 1)
        {
            this.transform.position = Player.transform.position + new Vector3(0.1f,0,0);
        }

        if (Player.transform.localScale.x == -1)
        {
            this.transform.position = Player.transform.position + new Vector3(-0.1f, 0, 0);
        }
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

        if (other.gameObject.tag == "Blob" && other.gameObject.GetComponent<BlobBehaviour>().Invincible == false)
        {
            other.gameObject.GetComponent<BlobBehaviour>().BlobHealth += -(SwordDamage * DamageMult);
            other.gameObject.GetComponent<BlobBehaviour>().Invincible = true;
            other.gameObject.GetComponent<BlobBehaviour>().Invoke("invincibleTimer", 1);
        }

        if (other.gameObject.tag == "Skeleton" && other.gameObject.GetComponent<SkeletonBehaviour>().Invincible == false)
        {
            other.gameObject.GetComponent<SkeletonBehaviour>().SkeleHealth += -(SwordDamage * DamageMult);
            other.gameObject.GetComponent<SkeletonBehaviour>().Invincible = true;
            other.gameObject.GetComponent<SkeletonBehaviour>().Invoke("invincibleTimer", 1);
        }

        if (other.gameObject.tag == "SkeletonMelee" && other.gameObject.GetComponent<SkeleMelee>().Invincible == false)
        {
            other.gameObject.GetComponent<SkeleMelee>().SkeleHealth += -(SwordDamage * DamageMult);
            other.gameObject.GetComponent<SkeleMelee>().Invincible = true;
            other.gameObject.GetComponent<SkeleMelee>().Invoke("invincibleTimer", 1);
        }
    }
}
