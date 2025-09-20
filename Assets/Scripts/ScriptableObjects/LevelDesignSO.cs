using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelDesign", menuName = "ScriptableObjects/LevelDesignSO")]
public class LevelDesignSO : ScriptableObject
{
    public List<LaneRow> laneRows;
    public int levelNumber;
}
