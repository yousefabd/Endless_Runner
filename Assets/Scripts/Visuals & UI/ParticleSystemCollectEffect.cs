using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemCollectEffect : MonoBehaviour
{
    private ParticleSystem _particleSystem;

    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        ScoreSystem.Instance.OnCollectibleChanged += ScoreSystem_OnCollectibleChanged;
    }
    private void ScoreSystem_OnCollectibleChanged()
    {
        _particleSystem.Play();
    }
}
