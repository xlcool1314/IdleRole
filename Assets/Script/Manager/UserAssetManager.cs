using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class UserAsset
{
    private int gold;

    private int level;

}


public class UserAssetManager:SingletonMono<UserAssetManager>{

    UserAsset asset = new UserAsset();

}