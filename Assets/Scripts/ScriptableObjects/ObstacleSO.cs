using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Obstacle", menuName = "ScriptableObjects/ObstacleSO", order = 1)]
public class ObstacleSO : ScriptableObject
{
    public Transform prefab;
    public float moveSpeed;
}
