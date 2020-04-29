using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUi : SingletonMono<ShopUi>
{
    public Button closeButton;

    private void Awake()
    {
        closeButton.onClick.AddListener(CloseShopUi);
    }
    public void CloseShopUi()
    {
        closeButton.onClick.RemoveAllListeners();
        Destroy(gameObject);
    }
}
