using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public class UserAsset
{
    [SerializeField]
    private int gold=10;

    [SerializeField]
    private int level=1;

    [SerializeField]
    private List<string> myRoleNames = null;

    public bool isFirstGame = true;//是否第一次进入游戏

    private bool isDirty=false;//是否是脏数据

    public int Gold 
    {
        get => gold;
        set
        {
            if(CheckIntValid(0,999999,value))
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
            if(CheckIntValid(0,999,value))
            {
                level = value; 
                SetDirty();
            }
        }
    }

    public List<string> MyRoleNames 
    { 
        get => myRoleNames;
        set 
        { 
            myRoleNames = value;
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


public class UserAssetManager:SingletonMono<UserAssetManager>{

    UserAsset asset = new UserAsset();//实例化用户资产

    bool inited = false;//是否初始化完成

        public override async Task Init()
    {
        if (inited)
        {
            return;
        }
        var json = PlayerPrefs.GetString("UserAsset", "{}");
        asset =JsonUtility.FromJson<UserAsset>(json);
        inited = true;
    }

        public override Task LateUpdateLoop()//保存判断
    {
        asset.Save();
        return null;
    }

    public void SaveGame()
    {
        asset.Save();
    }

    public void InitInfo()
    {
        PlayerPrefs.DeleteAll();
    }

    public void AddRole(string val)
    {
        asset.MyRoleNames.Add(val);
    }

    public List<string> MyAllRoles()
    {
        return asset.MyRoleNames;
    }

    public bool BoolRoles()
    {
        if (asset.MyRoleNames == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
        public int AddGold(int val)//增加金币
    {
        return asset.Gold += val;
    }

       public int ReduceGold(int val)//减少金币
    {
        return asset.Gold -= val;
    }

    public int UpdateGold()
    {
        return asset.Gold;
    }

        public int AddLevel()
    {
        return asset.Level+= 1;
    }
        
        public int GetLevel()
    {
        return asset.Level;
    }

       public bool IsFirstGame()
    {
        return asset.isFirstGame;
    }
}