using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUi : SingletonMono<ShopUi>
{
    public Button closeButton;

    public bool isOpenBuyRoleUi = false;

    private void Awake()
    {
        closeButton.onClick.AddListener(CloseShopUi);
    }
    public void CloseShopUi()
    {
        closeButton.onClick.RemoveAllListeners();
        if (ShopUi.Instance.isOpenBuyRoleUi == true)
        {
            Destroy(GameObject.Find("BuyRoleUi(Clone)").gameObject);
        }
        Destroy(gameObject);
    }
}
