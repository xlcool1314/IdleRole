using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUi : SingletonMono<ShopUi>
{
    public void CloseShopUi()
    {
        Destroy(gameObject);
    }
}
