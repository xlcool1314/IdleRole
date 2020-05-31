using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;

public class BuyRoleUi : UIBaseBehaviour
{
    public Button yesButton;

    public ShopRoleCell buyMyRole;

    public TextMeshProUGUI  nameText;//显示信息名称

    public TextMeshProUGUI damageText;//显示最小攻击力

    public TextMeshProUGUI defenseText;//显示防御力

    public TextMeshProUGUI hpText;//显示血量

    public TextMeshProUGUI treatmentTex;//显示治疗量

    public TextMeshProUGUI describeText;//显示描述

    public TextMeshProUGUI attckSpeedText;//频率显示

    public Image skin;

    public AllRoleData roleData;

    private void Awake()
    {
        InitInfo();
    }

    public async Task InitInfo()
    {
        var task = Addressables.LoadAssetAsync<AllRoleData>("AllRoleInfo").Task;
        roleData = await task;
        Init();
    }
    
    public override void Init()
    {
        yesButton.onClick.AddListener(DetermineBuyRole);
        if (roleData.roles.ContainsKey(ShopRoleCell.Instance.myRole.name))//角色数据初始化
        {
            nameText.text = ShopRoleCell.Instance.myRole.name;
            skin.sprite = roleData.roles[ShopRoleCell.Instance.myRole.name].mySkin;
            skin.SetNativeSize();
            damageText.text = roleData.roles[ShopRoleCell.Instance.myRole.name].damage[ShopRoleCell.Instance.myRole.GetComponent<RoleBase>().lv - 1].ToString();
            defenseText.text = roleData.roles[ShopRoleCell.Instance.myRole.name].defense[ShopRoleCell.Instance.myRole.GetComponent<RoleBase>().lv - 1].ToString();
            hpText.text = roleData.roles[ShopRoleCell.Instance.myRole.name].myMaxHp[ShopRoleCell.Instance.myRole.GetComponent<RoleBase>().lv - 1].ToString();
            treatmentTex.text = roleData.roles[ShopRoleCell.Instance.myRole.name].myTreatment[ShopRoleCell.Instance.myRole.GetComponent<RoleBase>().lv - 1].ToString();
            describeText.text = roleData.roles[ShopRoleCell.Instance.myRole.name].describe.ToString();
            attckSpeedText.text= roleData.roles[ShopRoleCell.Instance.myRole.name].maxAttackSpeed.ToString();
        }
    }

    public override void UpdateInfo(float deltaTime)
    {
        throw new System.NotImplementedException();
    }

    public override void Clean()//清除所有的监听
    {
        yesButton.onClick.RemoveAllListeners();
    }


    public void DetermineBuyRole()//确定购买我的角色
    {
        if(UserAssetManager.Instance.GetGold()>= ShopRoleCell.Instance.myRole.GetComponent<RoleBase>().howMuchMoneys)
        {
            Clean();
            UserAssetManager.Instance.ReduceGold(roleData.roles[ShopRoleCell.Instance.myRole.name].howMuchMoneys);
            MyRoleBuilder.Instance.CreatRole(ShopRoleCell.Instance.myRole);
            UserAssetManager.Instance.SaveRoleSta();
            BattlefieldMonitor.Instance.FindAllMyRole();
            BattlefieldMonitor.Instance.isFirstGame = false;
            ShopUi.Instance.CloseShopUi();
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("金币不够");
        }
        
    }
}
