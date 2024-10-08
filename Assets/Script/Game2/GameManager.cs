using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private int playerLife;
    [SerializeField] private int playerCoins;

    public event Action<int> OnLifeUpdate;
    public event Action<int> OnCoinUpdate;

    public event Action OnLose;
    public event Action OnWin;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }

        Instance = this;
    }

    private void Start()
    {
        playerCoins = 0;
    }

    public void GainCoin()
    {
        playerCoins++;

        OnCoinUpdate?.Invoke(playerCoins);
    }

    public void ModifyLife(int modify)
    {
        playerLife = Math.Clamp(playerLife + modify, 0, 10);

        OnLifeUpdate?.Invoke(playerLife);

        ValidaeLife();
    }

    public void CheckWin()
    {
        OnWin?.Invoke();
    }

    private void ValidaeLife()
    {
        if (playerLife == 0)
        {
            OnLose?.Invoke();
        }
    }
}
