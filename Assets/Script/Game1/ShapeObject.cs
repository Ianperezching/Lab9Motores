using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeObject : MonoBehaviour
{
    [SerializeField] private ColorShapeData shapeData;
    private SpriteRenderer spriteRenderer;

    public static event Action<Sprite> OnChangeShape;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetUp();
    }

    private void SetUp()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = shapeData.sprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnChangeShape?.Invoke(shapeData.sprite);
        }
    }
}
