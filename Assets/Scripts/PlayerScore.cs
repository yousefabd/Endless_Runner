using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private float currentDistance;
    private int currentDistaceInMeters = 0;

    private void Update()
    {
        float speed = GameSettings.Instance.GetPlayerSpeed();
        currentDistance += speed * Time.deltaTime;
        int newDistanceInMeters = Mathf.FloorToInt(currentDistance);
        if (newDistanceInMeters > currentDistaceInMeters)
        {
            currentDistaceInMeters = newDistanceInMeters;
            UpdateScore();
        }
    }
    private void UpdateScore()
    {
        ScoreSystem.Instance.AddDistance();
    }

}
