using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettingsSO")]
public class GameSettingsSO : ScriptableObject
{
    public float jumpForce = 5f;
    public float playerSpeed = 5f;
    public float laneWidth = 1.5f;
}
