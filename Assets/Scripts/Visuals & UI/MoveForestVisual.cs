using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForestVisual : MonoBehaviour
{
    [SerializeField] private Transform forestTransform;
    private List<Transform> forestObjects;

    private void Start()
    {
        forestObjects = new List<Transform>();
        foreach (Transform child in forestTransform.transform)
        {
            forestObjects.Add(child);
        }
    }
    private void Update()
    {
        foreach(Transform forestObject in forestObjects)
        {
            float newZ = forestObject.transform.position.z - GameSettings.Instance.GetPlayerSpeed() * Time.deltaTime;
            forestObject.position = new Vector3(forestObject.position.x, forestObject.position.y, newZ);
            if (forestObject.position.z < GameSettings.Instance.GetBlindSpotPosition().z)
            {
                forestObject.position = new Vector3(forestObject.position.x, forestObject.position.y, GameSettings.Instance.GetFarSpotPosition().z);
            }
        }
    }

}
