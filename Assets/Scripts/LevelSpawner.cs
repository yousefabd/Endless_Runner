using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> staticLevelPrefabs;
    [SerializeField] private List<Transform> movingLevelPrefabs;
    private enum SpawnerState { Static, Moving, Cooldown }
    private SpawnerState currentSpawnState;
    private int levelCountMax;
    private int levelCount;
    private float levelDistanceMax;
    private float levelDistance;
    private float cooldownTimerMax;
    private float cooldownTimer;

    private void Awake()
    {
        EnterState(SpawnerState.Static);
    }
    private void Update()
    {
        switch (currentSpawnState)
        {
            case SpawnerState.Static:
                HandleSpawningLevel();
                break;
            case SpawnerState.Moving:
                HandleSpawningLevel();
                break;
            case SpawnerState.Cooldown:
                HandleCooldown();
                break;
        }
    }
    private void EnterState(SpawnerState newState)
    {
        currentSpawnState = newState;
        levelCount = 0;
        levelDistance = 0f;
        switch (newState)
        {
            case SpawnerState.Static:
                levelCountMax = Random.Range(2, 4);
                break;
            case SpawnerState.Moving:
                levelCountMax = 1;
                break;
            case SpawnerState.Cooldown:
                cooldownTimerMax = 10f;
                cooldownTimer = cooldownTimerMax;
                break;
        }
    }
    private void HandleSpawningLevel()
    {
        levelDistance -= GameSettings.Instance.GetPlayerSpeed() * Time.deltaTime;
        if (levelDistance >= 0)
            return;
        if (levelCount >= levelCountMax)
        {
            if (currentSpawnState == SpawnerState.Static)
            {
                EnterState(SpawnerState.Cooldown);
                Debug.Log("start moving");
            }
            else if (currentSpawnState == SpawnerState.Moving)
            {
                EnterState(SpawnerState.Static);
            }
            return;
        }
        SpawnLevel();
        levelCount++;
    }
    private void SpawnLevel()
    {
        Transform levelPrefab;
        if (currentSpawnState == SpawnerState.Static)
        {
            int randomIndex = Random.Range(0, staticLevelPrefabs.Count);
            levelPrefab = staticLevelPrefabs[randomIndex];
        }
        else
        {
            int randomIndex = Random.Range(0, movingLevelPrefabs.Count);
            levelPrefab = movingLevelPrefabs[randomIndex];
        }
        Transform newLevel = Instantiate(levelPrefab, GameSettings.Instance.GetFarSpotPosition(),Quaternion.identity);
        float zSize = newLevel.GetComponent<LevelSettings>().GetZSize();
        levelDistance = zSize;
    }
    private void HandleCooldown()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0f)
        {
            EnterState(SpawnerState.Moving);
        }
    }
}
