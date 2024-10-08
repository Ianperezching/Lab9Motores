using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorObject : MonoBehaviour
{
    [SerializeField] private ColorShapeData colorData;
    private SpriteRenderer spriteRenderer;

    public static event Action<Color> OnChangeColor;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetUp();
    }

    private void SetUp()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = colorData.color;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnChangeColor?.Invoke(colorData.color);
        }
    }
}
