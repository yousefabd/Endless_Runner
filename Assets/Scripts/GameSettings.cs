using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance { get; private set; }

    [SerializeField] private GameSettingsSO gameSettingsSO;

    private void Awake()
    {
        Instance = this;
    }
    public float GetJumpForce()
    {
        return gameSettingsSO.jumpForce;
    }
    public float GetPlayerSpeed()
    {
        return gameSettingsSO.playerSpeed;
    }
    public float GetLaneWidth()
    {
        return gameSettingsSO.laneWidth;
    }
    public Vector3 GetBlindSpotPosition()
    {
        return gameSettingsSO.blindSpotPosition;
    }
    public Vector3 GetFarSpotPosition()
    {
        return gameSettingsSO.farSpotPosition;
    }
}
