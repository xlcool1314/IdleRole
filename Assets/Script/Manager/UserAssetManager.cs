using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;



public class UserAsset
{
    [System.Serializable]
    public struct RoleStatus
    {
        public string _name;
        public int _lv;
        public float _speed;
    }

    [SerializeField]
    private List<RoleStatus> saveRoleStatus = new List<RoleStatus>();//当前战斗状态相关数据

    [SerializeField]
    private int gold = 100;

    [SerializeField]
    private int level = 1;


    public bool isFirstGame = true;//是否第一次进入游戏

    private bool isDirty = false;//是否是脏数据

    public int Gold
    {
        get => gold;
        set
        {
            if (CheckIntValid(0, 999999, value))
            {
                gold = value;
                SetDirty();
            }

        }
    }

    public int Level
    {
        get => level;
        set
        {
            if (CheckIntValid(0, 999, value))
            {
                level = value;
                SetDirty();
            }
        }
    }

    public List<RoleStatus> SaveRoleStatus
    {
        get => saveRoleStatus;
        set
        {
            saveRoleStatus = value;
            SetDirty();
        }
    }

    private bool CheckIntValid(int min, int max, int val)//约束取值范围
    {
        if (min <= val && val <= max)
        {
            return true;
        }
        Debug.LogError("不符合取值范围");
        return false;
    }

    public void SetDirty()//脏数据判断
    {
        isDirty = true;
    }

    public void Save()
    {
        if (isDirty)
        {
            var json = JsonUtility.ToJson(this);
            Debug.Log("Save " + json);
            PlayerPrefs.SetString("UserAsset", json);
            PlayerPrefs.Save();
            isDirty = false;
        }
    }
}

public class DataStatistics//统计数据
{
    private int attacksNumber;//总的攻击次数

    private int treatmentNumber;//总治疗次数

    private int haveRoles;//获得的角色数量

    private int highestLevel;//最高关卡

    private bool isDirty = false;//是否是脏数据



    public int AttacksNumber { get => attacksNumber; set => attacksNumber = value; }
    public int HaveRoles { get => haveRoles; set => haveRoles = value; }
    public int TreatmentNumber { get => treatmentNumber; set => treatmentNumber = value; }
    public int HighestLevel { get => highestLevel; set => highestLevel = value; }

    private bool CheckIntValid(int min, int max, int val)//约束取值范围
    {
        if (min <= val && val <= max)
        {
            return true;
        }
        Debug.LogError("不符合取值范围");
        return false;
    }

    public void SetDirty()//脏数据判断
    {
        isDirty = true;
    }

    public void Save()
    {
        if (isDirty)
        {
            var json = JsonUtility.ToJson(this);
            Debug.Log("Save " + json);
            PlayerPrefs.SetString("DataStatistics", json);
            PlayerPrefs.Save();
            isDirty = false;
        }
    }
}


public class UserAssetManager : SingletonMono<UserAssetManager>
{

    UserAsset asset = new UserAsset();//实例化用户资产

    bool inited = false;//是否初始化完成

    public override async Task Init()
    {
        if (inited)
        {
            return;
        }
        var json = PlayerPrefs.GetString("UserAsset", "{}");
        asset = JsonUtility.FromJson<UserAsset>(json);
        inited = true;
    }

    public override Task LateUpdateLoop()//保存判断
    {
        asset.Save();
        return null;
    }

    public void SaveRoleSta()//储存场上角色状态
    {
        if (BattlefieldMonitor.Instance.allMyRoles != null)
        {
            for (int i = 0; i < BattlefieldMonitor.Instance.allMyRoles.Length; i++)
            {
                asset.SaveRoleStatus.Add(new UserAsset.RoleStatus()
                {
                    _lv = BattlefieldMonitor.Instance.allMyRoles[i].GetComponent<RoleBase>().lv,
                    _name = BattlefieldMonitor.Instance.allMyRoles[i].GetComponent<RoleBase>().name,
                    _speed = BattlefieldMonitor.Instance.allMyRoles[i].GetComponent<RoleBase>().maxAttackSpeed
                });

                asset.SetDirty();
            }
        }
    }

    public void SaveGame()//储存相关信息
    {
        asset.Save();
    }

    public void InitInfo()
    {
        PlayerPrefs.DeleteAll();
    }

    public int AddGold(int val)//增加金币
    {
        return asset.Gold += val;
    }

    public int ReduceGold(int val)//减少金币
    {
        return asset.Gold -= val;
    }

    public int GetGold()//更新金币数量
    {
        return asset.Gold;
    }

    public int AddLevel()//关卡增加
    {
        return asset.Level += 1;
    }

    public int GetLevel()//获得关卡信息
    {
        return asset.Level;
    }

    public bool IsFirstGame()//是否第一次进入游戏
    {
        return asset.isFirstGame;
    }
}