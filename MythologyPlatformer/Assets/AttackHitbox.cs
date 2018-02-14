using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Mosquito" && other.gameObject.GetComponent<MosquitoBehaviour>().Invincible == false)
        {
            other.gameObject.GetComponent<MosquitoBehaviour>().MosquitoHealth += -4;
            other.gameObject.GetComponent<MosquitoBehaviour>().Invincible = true;
            other.gameObject.GetComponent<MosquitoBehaviour>().Invoke("invincibleTimer", 1);
        }
    }
}
