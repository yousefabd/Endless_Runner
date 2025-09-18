using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnRoad : MonoBehaviour
{
    private Vector3 moveDirection = new(0, 0, -1);

    private void Update()
    {
        float moveSpeed = GameSettings.Instance.GetPlayerSpeed();
        transform.position += moveSpeed * Time.deltaTime * moveDirection;
        if (transform.position.z < GameSettings.Instance.GetBlindSpotPosition().z)
        {
            Destroy(gameObject);
        }
    }
}
