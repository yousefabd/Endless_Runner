using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class LevelBuilder : EditorWindow
{
    private LevelDesignSO levelDesignSO;
    private GameSettingsSO gameSettingsSO;
    private ObstacleListSO  obstacleSOList;
    private List<ObstacleSO> evadeObstacles;
    private List<ObstacleSO> blockedObstacles;
    private List<ObstacleSO> movingObstacles;
    private bool reversed;
    [MenuItem("Tools/Build Level")]
    public static void ShowWindow()
    {
        GetWindow<LevelBuilder>("Level Builder");
    }
    private void OnGUI()
    {
        GUILayout.Label("Level Builder", EditorStyles.boldLabel);
        levelDesignSO = (LevelDesignSO)EditorGUILayout.ObjectField("Level Design SO", levelDesignSO, typeof(LevelDesignSO), false);
        gameSettingsSO = (GameSettingsSO)EditorGUILayout.ObjectField("Game Settings SO", gameSettingsSO, typeof(GameSettingsSO), false);
        obstacleSOList = (ObstacleListSO)EditorGUILayout.ObjectField("Obstacle List SO", obstacleSOList, typeof(ObstacleListSO), false);
        reversed = EditorGUILayout.Toggle("Reverse Level",reversed);
        if (GUILayout.Button("Build Level"))
        {
            BuildLevel();
        }
    }
    private void BuildLevel()
    {
        evadeObstacles = obstacleSOList.list.FindAll(o => o.obstacleType.Equals(ObstacleType.Evade));
        blockedObstacles = obstacleSOList.list.FindAll(o => o.obstacleType.Equals(ObstacleType.Blocked));
        movingObstacles = obstacleSOList.list.FindAll(o => o.obstacleType.Equals(ObstacleType.Moving));
        GameObject root = new GameObject("Level");
        LevelSettings levelSettings = root.AddComponent<LevelSettings>();
        float[] zPositions = new float[3] { 0f, 0f, 0f };
        float maxZPosition = float.NegativeInfinity;
        float laneWidth = gameSettingsSO.laneWidth;
        for (int i = 0; i < levelDesignSO.laneRows.Count; i++)
        {
            GameObject rowGO = new GameObject($"Row{i}");
            rowGO.transform.parent = root.transform;
            LaneRow laneRow = levelDesignSO.laneRows[i];
            LaneItem[] laneItems = new LaneItem[3] { laneRow.leftLaneItem, laneRow.middleLaneItem, laneRow.rightLaneItem };
            Vector3[] spawnPositions = new Vector3[3]
            {
                new Vector3(-laneWidth, 0, zPositions[0]),
                new Vector3(0, 0, zPositions[1]),
                new Vector3(laneWidth, 0, zPositions[2])
            };
            for (int j = 0; j < 3; j++)
            {
                int laneIndex = reversed ? 2 - j : j;
                LaneItem laneItem = laneItems[j];
                ObstacleSO obstacle = GetRandomObstacle(laneItem.obstacleType);
                maxZPosition = Mathf.Max(zPositions[laneIndex], maxZPosition);
                SpawnObstacle(obstacle, spawnPositions[laneIndex], rowGO.transform);
                zPositions[laneIndex] += laneItem.laneOffsetZ;
            }
        }
        string reversedText = reversed ? "_Reversed" : "";
        string prefabName = $"Level{levelDesignSO.levelNumber}{reversedText}.prefab";
        string saveDir = "Assets/Prefabs/Levels";
        string savePath = $"{saveDir}/{prefabName}";
        if(!Directory.Exists(saveDir))
        {
            Directory.CreateDirectory(saveDir);
        }
        levelSettings.SetZSize(maxZPosition);
        PrefabUtility.SaveAsPrefabAsset(root, savePath);
        DestroyImmediate(root);
        Debug.Log($"Level prefab saved at: {savePath}");
    }
    private ObstacleSO GetRandomObstacle(ObstacleType obstacleType) {
        int randomIndex;
        switch (obstacleType)
        {
            case ObstacleType.Evade:
                randomIndex = Random.Range(0, evadeObstacles.Count);
                return evadeObstacles[randomIndex];
            case ObstacleType.Blocked:
                randomIndex = Random.Range(0, blockedObstacles.Count);
                return blockedObstacles[randomIndex];
            case ObstacleType.Moving:
                randomIndex = Random.Range(0, movingObstacles.Count);
                return movingObstacles[randomIndex];
            case ObstacleType.None:
                return null;
        }
        return null;
    }
    private void SpawnObstacle(ObstacleSO obstacle, Vector3 position, Transform parent)
    {
        if (obstacle == null) return;
        Instantiate(obstacle.prefab, position, Quaternion.identity, parent);
    }
}
