using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text lifeText;

    private void Start()
    {
        GameManager.Instance.OnLifeUpdate += OnLifeUpdate;  
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnLifeUpdate -= OnLifeUpdate;  
    }

  
    private void OnLifeUpdate(int life)
    {
        lifeText.text = life.ToString();
    }
}
