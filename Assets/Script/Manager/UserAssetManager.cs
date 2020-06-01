using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;



public class UserAsset//角色资产
{
    [System.Serializable]
    public struct RoleStatus
    {
        public string _name;
        public int _lv;
        public float _speed;
    }//储存角色相关信息

    [SerializeField]
    private List<RoleStatus> saveRoleStatus = new List<RoleStatus>();//当前战斗状态相关数据

    [SerializeField]
    private int gold = 20;

    [SerializeField]
    private int level = 1;

    [SerializeField]
    private float second=0;//计时器

    private bool isFirstGame = true;//是否第一次进入游戏

    private bool isOpenNextLevel=false;//是否开启下一关卡

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

    public float Second
    {
        get => second;
        set
        {
                second = value;
                SetDirty();
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

    public bool IsFirstGame
    {
        get => isFirstGame;
        set
        {
            isFirstGame = value;
            SetDirty();
        }
    }

    public bool IsOpenNextLevel
    {
        get => isOpenNextLevel;
        set
        {
            isOpenNextLevel = value;
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
        BattlefieldMonitor.Instance.FindAllMyRole();
        if (BattlefieldMonitor.Instance.allMyRoles != null)
        {
            asset.SaveRoleStatus.Clear();
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
        else
        {
            Debug.Log("没有角色储存");
        }
    }

    public List<UserAsset.RoleStatus> CreatRoleSta()
    {
            return asset.SaveRoleStatus;
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
        return asset.IsFirstGame;
    }

    public void YesFirstGame()
    {
        asset.IsFirstGame = true;
    }

    public void NoFirstGame()
    {
        asset.IsFirstGame = false;
    }

    public float GetTime()
    {
        return asset.Second;
    }
    public void SaveTime(float val)
    {
        asset.Second = val;
    }

    public bool OpenNextLevel()//切换是否可以打开门
    {
        return asset.IsOpenNextLevel=true;
    }

    public bool NoOpenNextLevel()//切换是否可以打开门
    {
        return asset.IsOpenNextLevel = false;
    }

    public bool GetMyOpenNextLevelBool()//切换是否可以打开门
    {
        return asset.IsOpenNextLevel;
    }
}