using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSettings : MonoBehaviour
{
    [SerializeField] private float zSize;

    public float GetZSize() {
        return zSize;
    }
    public void SetZSize(float zSize)
    {
        this.zSize = zSize;
    }
}
