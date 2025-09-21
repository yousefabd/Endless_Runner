using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem Instance { get; private set; }
    private int distance = 0;
    private int collectibles;

    private void Awake()
    {
        Instance = this;
    }
    public void AddCollectible()
    {
        collectibles += 10;
    }
    public void AddDistance()
    {
        distance++;
    }
    public int GetMaxScore()
    {
        return distance + collectibles;
    }


}
