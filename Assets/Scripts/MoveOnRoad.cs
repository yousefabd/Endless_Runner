using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnRoad : MonoBehaviour
{
    [SerializeField] private ObstacleSO obstacleSO;
    private Vector3 moveDirection = new(0, 0, -1);

    private void Update()
    {
        float obstacleSpeed = obstacleSO != null ? obstacleSO.moveSpeed : 0f;
        float moveSpeed = GameSettings.Instance.GetPlayerSpeed() + obstacleSpeed;
        transform.position += moveSpeed * Time.deltaTime * moveDirection;
        if (transform.position.z < GameSettings.Instance.GetBlindSpotPosition().z)
        {
            Destroy(gameObject);
        }
    }
}
