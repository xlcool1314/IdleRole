﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "Config/Create AllRoleData")]
public class AllRoleData : SerializedScriptableObject
{
    public Dictionary<string, RoleData> roles;
}

[System.Serializable]
public class RoleData
{
    [Title("是否解锁")]
    public bool isUnlock;
    [Title("皮肤")]
    public Sprite mySkin;
    [Title("属性")]
    public PropertyInfo property;
    [Title("攻击方式")]
    public SkillType skillType;
    [Title("等级")]
    public int lv;
    [Title("升级消耗的金币")]
    public List<int> lvUpMoney;
    [Title("最大血量")]
    public List<int> myMaxHp;
    [Title("防御")]
    public List<int> defense;
    [Title("攻击力")]
    public List<int> damage;
    [Title("治疗量")]
    public List<int> myTreatment;
    [Title("可以治疗的个数")]
    public int numberTreatmens;
    [Title("可以攻击的个数")]
    public int numberAttack;
    [Title("攻击间隔")]
    public float maxAttackSpeed;
    [Title("购买价格")]
    public int howMuchMoneys;
    [Title("掉落金币")]
    public int dropMoneys;
    [Title("动画控制器")]
    public Animator myAnimator;
    [Title("攻击特效")]
    public GameObject attackEffects;
    [Title("受击特效")]
    public GameObject underAttackEffects;
    [Title("死亡特效")]
    public GameObject deadEffects;
    [Title("技能描述")]
    public string describe;
}


[System.Serializable]
public enum PropertyInfo
{
    normal,
    fire,
    water,
    earth,
    wind
}

public enum SkillType
{
        NormalAttack,//普通攻击
        NormalTreatmens,//群体治疗
        TreatmenLowHp,//治疗血量最低
        AttackBackHp,//攻击时，随机治疗一个友方角色
        AttackReduceSpeed//攻击时，随机减少一个对方敌人的攻击进度条
}


