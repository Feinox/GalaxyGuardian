using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerSetting")]
public class PlayerSettings : ScriptableObject
{
    [SerializeField] private float speed;


    public float Speed
    {
        get => speed;
        set => speed = value;
    }

}