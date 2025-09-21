using UnityEngine;
[CreateAssetMenu(fileName = "Collectible", menuName = "ScriptableObjects/CollectibleSO")]
public class CollectibleSO : ScriptableObject
{
    public string collectibleName;
    public Transform prefab;
    public int scoreValue = 10;
}
