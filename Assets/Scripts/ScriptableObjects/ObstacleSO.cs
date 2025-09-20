using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public enum ObstacleType
{
    Evade,
    Blocked,
    Moving,
    None
}
[CreateAssetMenu(fileName = "Obstacle", menuName = "ScriptableObjects/ObstacleSO")]
public class ObstacleSO : ScriptableObject
{
    public Transform prefab;
    public float moveSpeed;
    public ObstacleType obstacleType;
}
