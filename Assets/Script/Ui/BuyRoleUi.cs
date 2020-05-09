using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyRoleUi : UIBaseBehaviour
{
    public Button yesButton;
    public Button noButton;

    public ShopRoleCell buyMyRole;

    public TextMeshProUGUI  nameText;//显示信息名称

    public TextMeshProUGUI damageText;//显示最小攻击力

    public TextMeshProUGUI defenseText;//显示防御力

    public Image skin;

    private void Awake()
    {
        Init();
    }
    
    public override void Init()
    {
        yesButton.onClick.AddListener(DetermineBuyRole);
        noButton.onClick.AddListener(CloseBuyRoleUi);
        nameText.text = ShopRoleCell.Instance.myRole.name;
        skin.sprite = ShopRoleCell.Instance.myRole.GetComponent<RoleBase>().mySkin.sprite;
        damageText.text = ShopRoleCell.Instance.myRole.GetComponent<RoleBase>().damage.ToString();
        defenseText.text = ShopRoleCell.Instance.myRole.GetComponent<RoleBase>().defense.ToString();
    }

    public override void UpdateInfo(float deltaTime)
    {
        throw new System.NotImplementedException();
    }

    public override void Clean()//清除所有的监听
    {
        yesButton.onClick.RemoveAllListeners();
        noButton.onClick.RemoveAllListeners();
    }


    public void DetermineBuyRole()//确定购买我的角色
    {
        if(UserAssetManager.Instance.UpdateGold()>= ShopRoleCell.Instance.myRole.GetComponent<RoleBase>().howMuchMoneys)
        {
            Clean();
            UserAssetManager.Instance.ReduceGold(ShopRoleCell.Instance.myRole.GetComponent<RoleBase>().howMuchMoneys);
            var go = MyRoleBuilder.Instance.CreatRole(ShopRoleCell.Instance.myRole);
            BattlefieldMonitor.Instance.FindAllMyRole();
            BattlefieldMonitor.Instance.isFirstGame = false;
            //BattlefieldMonitor.Instance.Combination(go);
            ShopUi.Instance.CloseShopUi();
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("金币不够");
        }
        
    }

    public void CloseBuyRoleUi()//关闭购买UI
    {
        Clean();
        Destroy(gameObject);
    }
}
