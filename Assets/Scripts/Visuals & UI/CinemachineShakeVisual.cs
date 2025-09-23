using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CinemachineShakeVisual : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;
    private CinemachineBasicMultiChannelPerlin basicMultiChannelPerlin;

    private float intensity = 5f;
    private float timer;
    private float timerMax = 0.1f;

    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        basicMultiChannelPerlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        basicMultiChannelPerlin.m_AmplitudeGain = 0f;
        timer = timerMax;
        Player.Instance.OnTakeDamage += Player_OnTakeDamage;
    }
    private void Update()
    {
        if (timer < timerMax)
        {
            timer += Time.deltaTime;
            basicMultiChannelPerlin.m_AmplitudeGain = Mathf.Lerp(intensity, 0, timer / timerMax);
        }
    }
    private void Player_OnTakeDamage()
    {
        timer = 0f;
    }
}
