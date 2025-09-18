using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private List<ObstacleSO> obstacleSOList;
    private List<Vector3> lanePositions;
    private enum SpawnState { StaticObstacles, MovingObstacles }
    private SpawnState currentState = SpawnState.StaticObstacles;
    private float staticObstacleSpawnTimerMax = 1.2f;
    private float staticObstacleSpawnTimer;

    private void Awake()
    {
        staticObstacleSpawnTimer = staticObstacleSpawnTimerMax;
    }

    private void Start()
    {
        InitializeLanePositions();
    }

    private void Update()
    {
        switch (currentState)
        {
            case SpawnState.StaticObstacles:
                HandleStaticObstacleSpawning();
                break;
            case SpawnState.MovingObstacles:
                break;
        }
    }

    private void InitializeLanePositions()
    {
        List<float> laneXPositions = new List<float> { -GameSettings.Instance.GetLaneWidth(), 0, GameSettings.Instance.GetLaneWidth() };
        lanePositions = new List<Vector3>();
        foreach (float x in laneXPositions)
        {
            lanePositions.Add(new Vector3(x, 0, 0));
        }
    }

    private void HandleStaticObstacleSpawning()
    {
        staticObstacleSpawnTimer -= Time.deltaTime;
        if (staticObstacleSpawnTimer <= 0)
        {
            staticObstacleSpawnTimer = Random.Range(staticObstacleSpawnTimerMax * 0.5f, staticObstacleSpawnTimerMax * 1.5f);
            SpawnStaticObstacle();
        }
    }

    private void SpawnStaticObstacle()
    {
        int randomLaneIndex = Random.Range(0, lanePositions.Count);
        int randomObstacleIndex = Random.Range(0, obstacleSOList.Count);
        Vector3 spawnPosition = lanePositions[randomLaneIndex] + GameSettings.Instance.GetFarSpotPosition();
        Instantiate(obstacleSOList[randomObstacleIndex].prefab, spawnPosition, Quaternion.identity);
    }
}
