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

}

[CreateAssetMenu(menuName = "Config/Create SkillConfig ")]
public class SkillConfigData : ScriptableObject
{
    public List<SkillDesc> skillConfig;
}
