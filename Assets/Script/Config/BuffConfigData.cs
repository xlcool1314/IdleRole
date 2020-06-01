using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;


public enum BuffType
{
    poisoning,
    bleeding
}

[System.Serializable]
public class BuffDesc
{
    public int time;

    public BuffType buff;

    public Image iocn;

    public string desc;
}

[CreateAssetMenu(menuName = "Config/Create BufflConfig ")]
public class BuffConfigData : SerializedScriptableObject
{
    public Dictionary<string, List<BuffDesc>> buffs;
}
