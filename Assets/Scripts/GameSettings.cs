using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance { get; private set; }

    [SerializeField] private GameSettingsSO gameSettingsSO;
    private int canMove = 1;
    private int currentLevel = 1;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        GameManager.Instance.OnGameOver += GameManager_OnGameOver;
        GameManager.Instance.OnRestart += GameManager_OnRestart;
    }
    private void GameManager_OnGameOver()
    {
        canMove = 0;
    }
    private void GameManager_OnRestart()
    {
        canMove = 1;
        currentLevel = 1;
    }
    public float GetJumpForce()
    {
        return gameSettingsSO.jumpForce;
    }
    public float GetPlayerSpeed()
    {
        return (gameSettingsSO.playerSpeed + (gameSettingsSO.currentLevel - 1) * 0.5f) * canMove;
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
        currentLevel++;
    }
}
