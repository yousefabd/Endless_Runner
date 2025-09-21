using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpinVisual : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 50f;
    [SerializeField] private float shakeHeight = 0.2f;
    [SerializeField] private float shakeFrequency = 1f;
    private float offsetHeight;
    private void Start()
    {
        offsetHeight = transform.localPosition.y;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.Self);
        float newY = Mathf.Sin(Time.time * shakeFrequency) * shakeHeight;

        Vector3 position = transform.localPosition;
        transform.localPosition = new Vector3(position.x, offsetHeight + newY, position.z);
    }

}
