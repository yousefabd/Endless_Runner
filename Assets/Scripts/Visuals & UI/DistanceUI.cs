using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DistanceUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI distanceText;

    private void Update()
    {
        distanceText.text = ScoreSystem.Instance.GetDistance().ToString();
    }
}
