using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Rigidbody moveRigidbody;
    public float speed;
    public void Start()
    {
       moveRigidbody = GetComponent<Rigidbody>();
       moveRigidbody.velocity = moveRigidbody.transform.forward * speed;
    }
}