using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]private ColorData enemyColor;
    private int damage = 1;

    public static event Action<ColorData, int> OnEnter;
    public static event Action OnExit;

    private void OnTriggerEnter(Collider other)
    {
        if (OnEnter != null)
            OnEnter(enemyColor, damage);
    }

    private void OnTriggerExit(Collider other)
    {
        if (OnExit != null)
            OnExit();
    }
}
