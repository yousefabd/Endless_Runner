using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class GlowOnCollect : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        ScoreSystem.Instance.OnCollectibleChanged += ScoreSystem_OnCollectibleChanged;

    }
    private void ScoreSystem_OnCollectibleChanged()
    {
        animator.SetTrigger("Glow");
    }
}
