using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(menuName = "Config/Create LevelData ")]
public class LevelData : ScriptableObject
{
    public List<LevelDesc> levelinfo;
}

[System.Serializable]
public class LevelDesc
{
    public int levelNumber;

    public EnemysData enemysData;
}

