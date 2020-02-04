﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;

public class ShopRoleCell : SingletonMono<ShopRoleCell>
{
    public Button myButton;

    public GameObject myRole;

    public void ShopRoleCellInit()
    {

        myButton = this.transform.GetComponent<Button>();
        myButton.onClick.AddListener(CreatBuyRoleUi);
    }

    private void Start()
    {
        ShopRoleCellInit();
    }

    public void CreatBuyRoleUi()
    {
        Addressables.InstantiateAsync("BuyRoleUi");
    }
}
