using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;

    private void Start()
    {
        GameManager.Instance.OnCoinUpdate += OnCoinUpdate; 
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnCoinUpdate -= OnCoinUpdate;  
    }

    
    private void OnCoinUpdate(int coins)
    {
        coinsText.text =  coins.ToString();
    }
}
