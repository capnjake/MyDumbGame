using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopObject : MonoBehaviour
{
    public string objName;
    public string objTooltip;
    public Sprite objSprite;

    SpriteRenderer render;

    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        render.sprite = objSprite;   
    }
}
