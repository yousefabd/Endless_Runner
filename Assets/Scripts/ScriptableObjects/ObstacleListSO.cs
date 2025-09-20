using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ObstacleList", menuName = "ScriptableObjects/ObstacleListSO")]
public class ObstacleListSO : ScriptableObject
{
    public List<ObstacleSO> list;
}
