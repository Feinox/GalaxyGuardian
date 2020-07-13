using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManeuver : MonoBehaviour
{
    public Vector2 startWait;
    public Vector2 maneuverTime;
    private float targetManeuver;
    public float dodge;
    public float maneuverSpeed;
    public Vector2 maneuverWait;
    private float currentSpeed;
    public Boundary boundary;
    public float tilt;
    private Rigidbody enemyRigidbody;

    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();

        currentSpeed = enemyRigidbody.velocity.z;
        StartCoroutine(Evade());
    }
    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));
        while (true)
        {
            targetManeuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
        }
    }
    private void Update()
    {
        float newManeuver = Mathf.MoveTowards(enemyRigidbody.velocity.x, targetManeuver, maneuverSpeed * Time.deltaTime);
        enemyRigidbody.velocity = new Vector3(newManeuver, 0.0f, currentSpeed);
        enemyRigidbody.position = new Vector3(Mathf.Clamp(enemyRigidbody.position.x, boundary.xMin, boundary.xMax), 0.0f, Mathf.Clamp(enemyRigidbody.position.z, boundary.zMin, boundary.zMax));
        enemyRigidbody.rotation = Quaternion.Euler(0f, 0f, enemyRigidbody.velocity.x * -tilt);
    }
}
  
