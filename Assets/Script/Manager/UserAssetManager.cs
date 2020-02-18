using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class UserAsset
{
    private int gold;

    private int haveRoles;

    private int level;

    public int HaveRoles { get => haveRoles; set => haveRoles = value; }
    public int Gold { get => gold; set => gold = value; }
    public int Level { get => level; set => level = value; }
}


public class UserAssetManager:SingletonMono<UserAssetManager>{

    UserAsset asset = new UserAsset();

}