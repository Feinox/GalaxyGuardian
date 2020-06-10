using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSize;
    private Transform currentObject;
    void Start()
    {
        currentObject = GetComponent<Transform>();
    }
    void Update()
    {
        currentObject.position = new Vector3(currentObject.position.x, currentObject.position.y, Mathf.Repeat(Time.time * scrollSpeed, tileSize));   
    }
}