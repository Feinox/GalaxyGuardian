using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject explosionPlayer;
    private GameObject cloneExplosion;
    public GameObject mega_exp;

    private void OnParticleCollision()
    {
        // клонирование префаба взрыва
        cloneExplosion = (GameObject)Instantiate(mega_exp, GetComponent<Rigidbody>().position, GetComponent<Rigidbody>().rotation);

        // уничтожение объекта на котором висит этот скрипт
        Destroy(gameObject);

        // уничтожение клона взрыва после его отработки
        Destroy(cloneExplosion, 0.7f);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            cloneExplosion = Instantiate(explosionPlayer, GetComponent<Rigidbody>().position, GetComponent<Rigidbody>().rotation) as GameObject;
            Destroy(other.gameObject);
            Destroy(gameObject);
            Destroy(cloneExplosion, 1f);
        }
        if (other.tag == "Bolt")
        {
            cloneExplosion = Instantiate(explosion, GetComponent<Rigidbody>().position, GetComponent<Rigidbody>().rotation) as GameObject;
            Destroy(other.gameObject);
            Destroy(gameObject);
            Destroy(cloneExplosion, 1f);
        }
    }
}
