using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        ScoreSystem.Instance.AddCollectible();
        Destroy(gameObject);
    }
}
