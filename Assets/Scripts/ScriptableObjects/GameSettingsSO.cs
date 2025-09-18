using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettingsSO")]
public class GameSettingsSO : ScriptableObject
{
    public float jumpForce = 5f;
    public float playerSpeed = 5f;
    public float laneWidth = 1.5f;
    public Vector3 blindSpotPosition = new Vector3(0, 0, -6f);
    public Vector3 farSpotPosition = new Vector3(0, 0, 70f);
}
