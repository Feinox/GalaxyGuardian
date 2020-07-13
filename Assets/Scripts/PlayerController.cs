using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerSettings _playerSettings;
    public Boundary boundary;
    public float tilt;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate = 0.5f;
    public float nextFire = 0.0f;
    public float fireRate2 = 0.5f;
    public GameObject super_shot;
    private Rigidbody playerRigidbody;
    private AudioSource sound;

    public void Update()
    {
        sound = GetComponent<AudioSource>();

        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            sound.Play();
        }
        if (Input.GetButton("Fire2") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate2;
            Instantiate(super_shot, shotSpawn.position, shotSpawn.rotation);
            sound.Play();
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        playerRigidbody = GetComponent<Rigidbody>();

        playerRigidbody.rotation = Quaternion.Euler(0f, 0f, playerRigidbody.velocity.x * -tilt);
        playerRigidbody.velocity = new Vector3(moveHorizontal, 0f, moveVertical) * _playerSettings.Speed;
        playerRigidbody.position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 0.0f,
            Mathf.Clamp(playerRigidbody.position.z, boundary.zMin, boundary.zMax));
    }
}
