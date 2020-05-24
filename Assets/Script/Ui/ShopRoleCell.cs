using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using TMPro;

public class ShopRoleCell : SingletonMono<ShopRoleCell>
{
    public Button myButton;

    public GameObject myRole;

    public Image skin;

    public TextMeshProUGUI moneyText;

    public TextMeshProUGUI nameText;

    public void ShopRoleCellInit()
    {

        myButton = this.transform.GetComponent<Button>();
        myButton.onClick.AddListener(CreatBuyRoleUi);
    }

    private void Start()
    {
        ShopRoleCellInit();
    }

    public void CreatBuyRoleUi()//创建确定购买的UI
    {
        if (ShopUi.Instance.isOpenBuyRoleUi == true)
        {
            Destroy(GameObject.Find("BuyRoleUi(Clone)").gameObject);
        }
        ShopRoleCell.Instance.myRole=this.myRole;
        Addressables.InstantiateAsync("BuyRoleUi");
        ShopUi.Instance.isOpenBuyRoleUi = true;
    }
}
