using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class UserAsset
{
    private int gold;

    private int haveRoles;

    public int HaveRoles { get => haveRoles; set => haveRoles = value; }
    public int Gold { get => gold; set => gold = value; }

    public void Save()
    {
       var json = JsonUtility.ToJson(this);
       Debug.Log("Save " + json);
       PlayerPrefs.SetString("UserAsset", json);
       PlayerPrefs.Save();
    }
}


public class UserAssetManager:SingletonMono<UserAssetManager>{

    UserAsset asset = new UserAsset();

    bool inited = false;

    public override async Task Init()
    {
        if (inited)
        {
            return;
        }

        var json = PlayerPrefs.GetString("UserAsset", "{}");
        Debug.Log("Load " + json);
        asset = JsonUtility.FromJson<UserAsset>(json);
        inited = true;
    }

}