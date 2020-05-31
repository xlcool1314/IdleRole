using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;

public class RoleBase : MonoBehaviour
{
    public bool isUnlock;//是否解锁

    public string roleName;//角色姓名

    public PropertyInfo property;//角色属性

    public SkillType skillType;//角色技能

    public int lv;//角色等级

    [SerializeField]

    private int myhp;//血量

    public List<int> maxHp;//最大血量

    public List<int> defense;//防御

    public List<int> damage;//攻击力

    public List<int> myTreatment;// 治疗量

    public List<int> lvUpMoney;//升级所需要的金币

    public int numberTreatmens;//治疗个数

    public int numberAttack;//攻击目标个数

    public int howMuchMoneys;//购买需要的金币数量

    public float maxAttackSpeed;//最大的的攻击间隔

    public int dropMoneys;//掉落金币数量

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

    public Image mySkin;//我的皮肤

    public Image myHpBarImage;//我的血条image

    public string describe;//角色描述

    [HideInInspector]
    public AllRoleData roleData;

    [HideInInspector]
    public bool isDead=false;

    public AttackBase attackType;//攻击方式

    public int Myhp
    {
        get => myhp;
        set
        {
            if (value > maxHp[lv - 1])
            {
                myhp = maxHp[lv - 1];
            }
            else if (value < 0)
            {
                myhp = 0;
            }
            else
            {
                myhp = value;
            }
        }
    }//血量属性

    public async void RoleInitInfo()//初始化角色数据
    {
        UseSkill(skillType);//初始化角色使用的技能
        var task = Addressables.LoadAssetAsync<AllRoleData>("AllRoleInfo").Task;
        roleData = await task;
        if (roleData.roles.ContainsKey(roleName))//角色数据初始化
        {
            hpBar.currentfill = 1;//初始的血条为满
            isUnlock = roleData.roles[roleName].isUnlock;
            property = roleData.roles[roleName].property;
            lv = roleData.roles[roleName].lv;
            lvUpMoney = roleData.roles[roleName].lvUpMoney;
            maxHp = roleData.roles[roleName].myMaxHp;
            defense = roleData.roles[roleName].defense;
            mySkin.sprite = roleData.roles[roleName].mySkin;
            damage = roleData.roles[roleName].damage;
            myTreatment = roleData.roles[roleName].myTreatment;
            numberTreatmens = roleData.roles[roleName].numberTreatmens;
            numberAttack = roleData.roles[roleName].numberAttack;
            maxAttackSpeed = roleData.roles[roleName].maxAttackSpeed;
            howMuchMoneys = roleData.roles[roleName].howMuchMoneys;
            dropMoneys = roleData.roles[roleName].dropMoneys;
            myAnimator = transform.Find("Skin").GetComponent<Animator>();
            attackEffects = roleData.roles[roleName].attackEffects;
            underAttackEffects = roleData.roles[roleName].underAttackEffects;
            deadEffects = roleData.roles[roleName].deadEffects;
            describe = roleData.roles[roleName].describe;
            skillType = roleData.roles[roleName].skillType;
            Myhp = maxHp[lv-1];
            allRoles = GameObject.FindObjectOfType<BattlefieldMonitor>();//拿到存着的所有角色
            attackSpeedBar.currentfill = 0;//初始的攻击速度为0
            hpBar.Initialize(Myhp, maxHp[lv - 1]);//初始化血条的显示
            attackSpeedBar.Initialize(maxAttackSpeed, maxAttackSpeed);//初始话攻击速度的显示
            StartCoroutine(attackType.AttackCountdown(maxAttackSpeed, attackSpeedBar));//游戏开始进行第一次的攻击频率倒计时
        }

    }

    public void RoleUpDate()//bar更新
    {
        hpBar.CurrentValue = Myhp;
    }

    public void UseSkill(SkillType skill)//使用技能
    {
        switch (skill)
        {
            case SkillType.NormalAttack:

                attackType = gameObject.AddComponent<NormalAttack>();

                break;

            case SkillType.NormalTreatmens:

                attackType = gameObject.AddComponent<NormalTreatmens>();

                break;

            case SkillType.TreatmenLowHp:

                attackType = gameObject.AddComponent<TreatmenLowHp>();

                break;

            case SkillType.AttackBackHp:

                attackType = gameObject.AddComponent<AttackBackHp>();

                break;

            case SkillType.AttackReduceSpeed:

                attackType = gameObject.AddComponent<AttackReduceSpeed>();

                break;
        }
             
    }

}