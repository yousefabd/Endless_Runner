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
        return gameSettingsSO.playerSpeed + (gameSettingsSO.currentLevel - 1) * 0.5f;
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
    public float GetLaneMoveSpeed()
    {
        return gameSettingsSO.laneMoveSpeed;
    }
    public int GetCurrentLevel()
    {
        return gameSettingsSO.currentLevel;
    }
    public void LevelUp()
    {
        gameSettingsSO.currentLevel++;
    }
}
