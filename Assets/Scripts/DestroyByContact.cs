using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject explosionPlayer;
    private GameObject cloneExplosion;
    public GameObject mega_exp;
    private Rigidbody cloneRigidbody;

    private void OnParticleCollision()
    {
        cloneRigidbody = GetComponent<Rigidbody>();
        // клонирование префаба взрыва
        cloneExplosion = (GameObject)Instantiate(mega_exp, cloneRigidbody.position, cloneRigidbody.rotation);

        // уничтожение объекта на котором висит этот скрипт
        Destroy(gameObject);

        // уничтожение клона взрыва после его отработки
        Destroy(cloneExplosion, 0.7f);

    }

    private void OnTriggerEnter(Collider other)
    {
        cloneRigidbody = GetComponent<Rigidbody>();

        if (other.tag == "Player")
        {
            cloneExplosion = Instantiate(explosionPlayer, cloneRigidbody.position, cloneRigidbody.rotation) as GameObject;
            Destroy(other.gameObject);
            Destroy(gameObject);
            Destroy(cloneExplosion, 1f);
        }
        if (other.tag == "Bolt")
        {
            cloneExplosion = Instantiate(explosion, cloneRigidbody.position, cloneRigidbody.rotation) as GameObject;
            Destroy(other.gameObject);
            Destroy(gameObject);
            Destroy(cloneExplosion, 1f);
        }
    }
}
