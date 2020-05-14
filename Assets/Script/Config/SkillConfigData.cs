using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public enum Buff
{
    damageUp,
    attackSpeedUp

}

[System.Serializable]
public class SkillDesc
{
    public int time;

    public Buff buff;
}

[CreateAssetMenu(menuName = "Config/Create SkillConfig ")]
public class SkillConfigData : SerializedScriptableObject
{
    public Dictionary<string, List<SkillDesc>> test;
}
