using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class MoveFloorVisual : MonoBehaviour
{
    private Material floorMaterial;
    private float moveValue;
    private float uvSpeedFactor;

    private void Start()
    {
        floorMaterial = GetComponent<MeshRenderer>().material;

        float scaleZ = transform.localScale.z;
        uvSpeedFactor = 1f / scaleZ;
    }

    private void Update()
    {
        float playerSpeed = GameSettings.Instance.GetPlayerSpeed();
        moveValue -= playerSpeed * uvSpeedFactor * Time.deltaTime;
        floorMaterial.SetFloat("_MoveValue", moveValue);
    }
}
