using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Transform heartContainerTemplate;
    private List<Transform> heartContainerList;
    int currentHeartTransformIndex;

    private void Start()
    {
        heartContainerList = new List<Transform>();
        GameManager.Instance.OnPlayerReady += GameManager_OnPlayerReady;
    }
    private void GameManager_OnPlayerReady()
    {
        int maxLives = HealthSystem.Instance.GetMaxLives();
        Player.Instance.OnTakeDamage += Player_OnTakeDamage;
        for (int i = 0; i < maxLives; i++)
        {
            Transform heartContainerTransform = Instantiate(heartContainerTemplate, transform);
            heartContainerTransform.gameObject.SetActive(true);
            heartContainerList.Add(heartContainerTransform);
        }
        currentHeartTransformIndex = heartContainerList.Count - 1;   
    }
    private void Player_OnTakeDamage()
    {
        if (currentHeartTransformIndex < 0) return;
        Transform heartContainerTransform = heartContainerList[currentHeartTransformIndex];
        heartContainerTransform.Find("heart").GetComponent<Animator>().SetTrigger("Disappear");
        currentHeartTransformIndex--;
    }
}
