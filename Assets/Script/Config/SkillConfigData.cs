using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Buff
{
    damageUp,
    attackSpeedUp

}

[System.Serializable]
public class SkillDesc
{
    public int time;
}

[CreateAssetMenu(menuName = "Config/Create SkillConfig ")]
public class SkillConfigData : ScriptableObject
{
    public List<SkillDesc> skillConfig;
}
