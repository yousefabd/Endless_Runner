using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingTerrain : MonoBehaviour
{
    [SerializeField] private Transform testMoveObject;
    [SerializeField] private Transform blindSpotTransform;

    private void Update()
    {
        float moveSpeed = GameSettings.Instance.GetPlayerSpeed();
        testMoveObject.position += new Vector3(0, 0, -moveSpeed * Time.deltaTime);
        if(testMoveObject.position.z < blindSpotTransform.position.z)
        {
            testMoveObject.position += new Vector3(0, 0, 70f);
        }
    }
}
