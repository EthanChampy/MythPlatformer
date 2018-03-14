using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour {

    public int SwordDamage = 2;
    public int DamageMult = 1;

    GameObject Player;

    void Start()
    {
        Invoke("SwordStatSet", 0.2f);
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Player.transform.localScale.x == 1)
        {
            this.transform.position = Player.transform.position + new Vector3(0.1f,0.05f,0);
        }

        if (Player.transform.localScale.x == -1)
        {
            this.transform.position = Player.transform.position + new Vector3(-0.1f, 0.05f, 0);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Mosquito" && other.gameObject.GetComponent<MosquitoBehaviour>().Invincible == false)
        {
            other.gameObject.GetComponent<MosquitoBehaviour>().MosquitoHealth += -(SwordDamage * DamageMult * 2);
            other.gameObject.GetComponent<MosquitoBehaviour>().Invincible = true;
            other.gameObject.GetComponent<MosquitoBehaviour>().Invoke("invincibleTimer", 1);
            other.gameObject.GetComponent<MosquitoBehaviour>().Invoke("ColorOff", 0f);
            other.gameObject.GetComponent<MosquitoBehaviour>().Invoke("ColorOn", 0.15f);
            other.gameObject.GetComponent<MosquitoBehaviour>().Invoke("ColorOff", 0.3f);
            other.gameObject.GetComponent<MosquitoBehaviour>().Invoke("ColorOn", 0.45f);
            other.gameObject.GetComponent<MosquitoBehaviour>().Invoke("ColorOff", 0.6f);
            other.gameObject.GetComponent<MosquitoBehaviour>().Invoke("ColorOn", 0.75f);
        }

        if (other.gameObject.tag == "MosqZomb" && other.gameObject.GetComponent<MosqZombieBehaviour>().Invincible == false)
        {
            other.gameObject.GetComponent<MosqZombieBehaviour>().ZombieHealth += -(SwordDamage * DamageMult);
            other.gameObject.GetComponent<MosqZombieBehaviour>().Invincible = true;
            other.gameObject.GetComponent<MosqZombieBehaviour>().Invoke("invincibleTimer", 1);
            other.gameObject.GetComponent<MosqZombieBehaviour>().Invoke("ColorOff", 0f);
            other.gameObject.GetComponent<MosqZombieBehaviour>().Invoke("ColorOn", 0.15f);
            other.gameObject.GetComponent<MosqZombieBehaviour>().Invoke("ColorOff", 0.3f);
            other.gameObject.GetComponent<MosqZombieBehaviour>().Invoke("ColorOn", 0.45f);
            other.gameObject.GetComponent<MosqZombieBehaviour>().Invoke("ColorOff", 0.6f);
            other.gameObject.GetComponent<MosqZombieBehaviour>().Invoke("ColorOn", 0.75f);
        }

        if (other.gameObject.tag == "Warrior" && other.gameObject.GetComponent<WarriorBehaviour>().Invincible == false && Player.transform.localScale.x == other.gameObject.transform.localScale.x)
        {
            other.gameObject.GetComponent<WarriorBehaviour>().WarriorHealth += -(SwordDamage * DamageMult);
            other.gameObject.GetComponent<WarriorBehaviour>().Invincible = true;
            other.gameObject.GetComponent<WarriorBehaviour>().Invoke("invincibleTimer", 1);
            other.gameObject.GetComponent<WarriorBehaviour>().Invoke("ColorOff", 0f);
            other.gameObject.GetComponent<WarriorBehaviour>().Invoke("ColorOn", 0.15f);
            other.gameObject.GetComponent<WarriorBehaviour>().Invoke("ColorOff", 0.3f);
            other.gameObject.GetComponent<WarriorBehaviour>().Invoke("ColorOn", 0.45f);
            other.gameObject.GetComponent<WarriorBehaviour>().Invoke("ColorOff", 0.6f);
            other.gameObject.GetComponent<WarriorBehaviour>().Invoke("ColorOn", 0.75f);
        }

        if (other.gameObject.tag == "Blob" && other.gameObject.GetComponent<BlobBehaviour>().Invincible == false)
        {
            other.gameObject.GetComponent<BlobBehaviour>().BlobHealth += -(SwordDamage * DamageMult);
            other.gameObject.GetComponent<BlobBehaviour>().Invincible = true;
            other.gameObject.GetComponent<BlobBehaviour>().Invoke("invincibleTimer", 1);
            other.gameObject.GetComponent<BlobBehaviour>().Invoke("ColorOff", 0f);
            other.gameObject.GetComponent<BlobBehaviour>().Invoke("ColorOn", 0.15f);
            other.gameObject.GetComponent<BlobBehaviour>().Invoke("ColorOff", 0.3f);
            other.gameObject.GetComponent<BlobBehaviour>().Invoke("ColorOn", 0.45f);
            other.gameObject.GetComponent<BlobBehaviour>().Invoke("ColorOff", 0.6f);
            other.gameObject.GetComponent<BlobBehaviour>().Invoke("ColorOn", 0.75f);
        }

        if (other.gameObject.tag == "MegaBlob" && other.gameObject.GetComponent<MegaBlob>().Invincible == false)
        {
            other.gameObject.GetComponent<MegaBlob>().BlobHealth += -(SwordDamage * DamageMult);
            other.gameObject.GetComponent<MegaBlob>().Invincible = true;
            other.gameObject.GetComponent<MegaBlob>().Invoke("invincibleTimer", 1);
            other.gameObject.GetComponent<MegaBlob>().Invoke("ColorOff", 0f);
            other.gameObject.GetComponent<MegaBlob>().Invoke("ColorOn", 0.15f);
            other.gameObject.GetComponent<MegaBlob>().Invoke("ColorOff", 0.3f);
            other.gameObject.GetComponent<MegaBlob>().Invoke("ColorOn", 0.45f);
            other.gameObject.GetComponent<MegaBlob>().Invoke("ColorOff", 0.6f);
            other.gameObject.GetComponent<MegaBlob>().Invoke("ColorOn", 0.75f);
        }

        if (other.gameObject.tag == "Skeleton" && other.gameObject.GetComponent<SkeletonBehaviour>().Invincible == false)
        {
            other.gameObject.GetComponent<SkeletonBehaviour>().SkeleHealth += -(SwordDamage * DamageMult);
            other.gameObject.GetComponent<SkeletonBehaviour>().Invincible = true;
            other.gameObject.GetComponent<SkeletonBehaviour>().Invoke("invincibleTimer", 1);
            other.gameObject.GetComponent<SkeletonBehaviour>().Invoke("ColorOff", 0f);
            other.gameObject.GetComponent<SkeletonBehaviour>().Invoke("ColorOn", 0.15f);
            other.gameObject.GetComponent<SkeletonBehaviour>().Invoke("ColorOff", 0.3f);
            other.gameObject.GetComponent<SkeletonBehaviour>().Invoke("ColorOn", 0.45f);
            other.gameObject.GetComponent<SkeletonBehaviour>().Invoke("ColorOff", 0.6f);
            other.gameObject.GetComponent<SkeletonBehaviour>().Invoke("ColorOn", 0.75f);
        }

        if (other.gameObject.tag == "SkeletonMelee" && other.gameObject.GetComponent<SkeleMelee>().Invincible == false)
        {
            other.gameObject.GetComponent<SkeleMelee>().SkeleHealth += -(SwordDamage * DamageMult);
            other.gameObject.GetComponent<SkeleMelee>().Invincible = true;
            other.gameObject.GetComponent<SkeleMelee>().Invoke("invincibleTimer", 1);
            other.gameObject.GetComponent<SkeleMelee>().Invoke("ColorOff", 0f);
            other.gameObject.GetComponent<SkeleMelee>().Invoke("ColorOn", 0.15f);
            other.gameObject.GetComponent<SkeleMelee>().Invoke("ColorOff", 0.3f);
            other.gameObject.GetComponent<SkeleMelee>().Invoke("ColorOn", 0.45f);
            other.gameObject.GetComponent<SkeleMelee>().Invoke("ColorOff", 0.6f);
            other.gameObject.GetComponent<SkeleMelee>().Invoke("ColorOn", 0.75f);
        }

        if (other.gameObject.tag == "Pestilence" && other.gameObject.GetComponent<Pestilence>().Invincible == false)
        {
            other.gameObject.GetComponent<Pestilence>().PestHealth += -(SwordDamage * DamageMult);
            other.gameObject.GetComponent<Pestilence>().Invincible = true;
            other.gameObject.GetComponent<Pestilence>().Invoke("invincibleTimer", 1);
            other.gameObject.GetComponent<Pestilence>().Invoke("ColorOff", 0f);
            other.gameObject.GetComponent<Pestilence>().Invoke("ColorOn", 0.15f);
            other.gameObject.GetComponent<Pestilence>().Invoke("ColorOff", 0.3f);
            other.gameObject.GetComponent<Pestilence>().Invoke("ColorOn", 0.45f);
            other.gameObject.GetComponent<Pestilence>().Invoke("ColorOff", 0.6f);
            other.gameObject.GetComponent<Pestilence>().Invoke("ColorOn", 0.75f);
        }

        if (other.gameObject.tag == "War" && other.gameObject.GetComponent<War>().Invincible == false)
        {
            other.gameObject.GetComponent<War>().WarHealth += -(SwordDamage * DamageMult);
            other.gameObject.GetComponent<War>().Invincible = true;
            other.gameObject.GetComponent<War>().Invoke("invincibleTimer", 1);
            other.gameObject.GetComponent<War>().Invoke("ColorOff", 0f);
            other.gameObject.GetComponent<War>().Invoke("ColorOn", 0.15f);
            other.gameObject.GetComponent<War>().Invoke("ColorOff", 0.3f);
            other.gameObject.GetComponent<War>().Invoke("ColorOn", 0.45f);
            other.gameObject.GetComponent<War>().Invoke("ColorOff", 0.6f);
            other.gameObject.GetComponent<War>().Invoke("ColorOn", 0.75f);
        }

        if (other.gameObject.tag == "Famine" && other.gameObject.GetComponent<Famine>().Invincible == false)
        {
            other.gameObject.GetComponent<Famine>().FamineHealth += -(SwordDamage * DamageMult);
            other.gameObject.GetComponent<Famine>().Invincible = true;
            other.gameObject.GetComponent<Famine>().Invoke("invincibleTimer", 1);
            other.gameObject.GetComponent<Famine>().Invoke("ColorOff", 0f);
            other.gameObject.GetComponent<Famine>().Invoke("ColorOn", 0.15f);
            other.gameObject.GetComponent<Famine>().Invoke("ColorOff", 0.3f);
            other.gameObject.GetComponent<Famine>().Invoke("ColorOn", 0.45f);
            other.gameObject.GetComponent<Famine>().Invoke("ColorOff", 0.6f);
            other.gameObject.GetComponent<Famine>().Invoke("ColorOn", 0.75f);
        }

        if (other.gameObject.tag == "Death" && other.gameObject.GetComponent<Death>().Invincible == false)
        {
            other.gameObject.GetComponent<Death>().DeathHealth += -(SwordDamage * DamageMult);
            other.gameObject.GetComponent<Death>().Invincible = true;
            other.gameObject.GetComponent<Death>().Invoke("invincibleTimer", 1);
            other.gameObject.GetComponent<Death>().Invoke("ColorOff", 0f);
            other.gameObject.GetComponent<Death>().Invoke("ColorOn", 0.15f);
            other.gameObject.GetComponent<Death>().Invoke("ColorOff", 0.3f);
            other.gameObject.GetComponent<Death>().Invoke("ColorOn", 0.45f);
            other.gameObject.GetComponent<Death>().Invoke("ColorOff", 0.6f);
            other.gameObject.GetComponent<Death>().Invoke("ColorOn", 0.75f);
        }
    }

    void SwordStatSet()
    {
        DamageMult = PlayerPrefs.GetInt("Damage");
    }
}
