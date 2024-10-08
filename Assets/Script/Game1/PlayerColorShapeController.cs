using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorShapeController : MonoBehaviour
{
    [SerializeField] private ColorShapeData playerData;
    private SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        ColorObject.OnChangeColor += UpdateColor;
        ShapeObject.OnChangeShape += UpdateShape;
    }

    private void OnDisable()
    {
        ColorObject.OnChangeColor -= UpdateColor;
        ShapeObject.OnChangeShape -= UpdateShape;
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetUp();
    }

    private void SetUp()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = playerData.color;
            spriteRenderer.sprite = playerData.sprite;
        }
    }

    private void UpdateColor(Color newColor)
    {
        spriteRenderer.color = newColor;
    }

    private void UpdateShape(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }
}
