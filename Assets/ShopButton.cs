using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    public ShopObject shopObject;
    public Image buttonImageComponent;

    private void Start()
    {
        if (shopObject.objSprite)
            buttonImageComponent.sprite = shopObject.objSprite;
    }
}
