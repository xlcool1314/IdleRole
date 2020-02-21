using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/Create AllRoleData")]
public class AllRoleData : ScriptableObject
{
    public List<RoleData> AllRoleInfo;//所有角色信息

}

[System.Serializable]
public class RoleData
{
    public List<RoleInfo> RoleInfo;//某个角色信息
}

[System.Serializable]
public class RoleInfo
{
    public string name;//怪物名称

    public string describe;//描述

    public int myhp;//血量

    public int maxHp;//最大血量

    public int defense;//防御

    public int mindamage;//最小攻击力

    public int maxdamage;//最大攻击力

    public int myTreatment;// 治疗量

    public float maxAttackSpeed;//最大的的攻击间隔

    public Animator myAnimator;//动画控制器

    public GameObject attackEffects;//攻击特效

    public GameObject underAttackEffects;//受击特效

    public GameObject deadEffects;//死亡特效

    public BattlefieldMonitor allRoles;//所有角色

    public Stat hpBar;//血条

    public Stat attackSpeedBar;//攻击频率条

    public LossHp lossHpText;//显示伤害数字的脚本

    public LossHp treatmentText;//显示的治疗量

    public Animator lossAnimator;//伤害数字的显示动画

    public Animator treatmentAnimator;//治疗数字显示动画
}
