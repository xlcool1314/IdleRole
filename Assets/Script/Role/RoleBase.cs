using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class RoleBase : MonoBehaviour
{
    [EnumPaging]
    public enum Property//角色属性
    {
        normal,
        fire,
        water,
        earth,
        wind
    }
    public Property property;//角色属性

    public int lv;//角色等级

    [SerializeField]

    private int myhp;//血量

    public List<int> maxHp;//最大血量

    public List<int> defense;//防御

    public List<int> damage;//攻击力

    public List<int> myTreatment;// 治疗量

    public int numberTreatmens;//治疗个数

    public int numberAttack;//攻击目标个数

    public float maxAttackSpeed;//最大的的攻击间隔

    public int howMuchMoneys;//需要的金币数量

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

    public void RoleUpDate()//bar更新
    {
        hpBar.CurrentValue = Myhp;
    }

    public void AttackUpDate()//攻击伤害更新
    {
        if (attackSpeedBar.currentfill == 1 && attackSpeedBar.content.fillAmount > 0.99f)
        {
            attackSpeedBar.content.fillAmount = 0;
            attackSpeedBar.currentfill = 0;
            Attack(myAnimator);
            StartCoroutine(AttackCountdown(maxAttackSpeed, attackSpeedBar));
        }
    }

    public void TreatmentUpDate()//治疗更新
    {
        if (attackSpeedBar.currentfill == 1 && attackSpeedBar.content.fillAmount > 0.99f)
        {
            attackSpeedBar.content.fillAmount = 0;
            attackSpeedBar.currentfill = 0;
            Treatments(numberTreatmens);
            StartCoroutine(AttackCountdown(maxAttackSpeed, attackSpeedBar));
        }
    }

    public void InitRoleBase() //初始化
    {
        Myhp = maxHp[lv - 1];
        allRoles = GameObject.FindObjectOfType<BattlefieldMonitor>();//拿到存着的所有角色
        attackSpeedBar.currentfill = 0;//初始的攻击速度为0
        hpBar.currentfill = 1;//初始的血条为满
        hpBar.Initialize(Myhp, maxHp[lv - 1]);//初始化血条的显示
        attackSpeedBar.Initialize(maxAttackSpeed, maxAttackSpeed);//初始话攻击速度的显示
        StartCoroutine(AttackCountdown(maxAttackSpeed, attackSpeedBar));//游戏开始进行第一次的攻击频率倒计时
    }

    public virtual void Attack(Animator attackAnimator)//单体攻击相关
    {
        GameObject go = FindTheTarget();//找到要攻击的随机目标
        if (go != null)
        {
            
            go.GetComponent<RoleBase>().Myhp -= DamageCalculation(damage[lv - 1], go.GetComponent<RoleBase>().defense[lv - 1]);//计算出伤害然后在血量里面减去
            go.GetComponent<RoleBase>().lossAnimator.SetTrigger("LossHp");
            go.GetComponent<RoleBase>().lossHpText.hpText = DamageCalculation(damage[lv - 1], go.GetComponent<RoleBase>().defense[lv - 1]);
            attackAnimator.SetTrigger("Attack");
            go.GetComponent<RoleBase>().myAnimator.SetTrigger("numberAttack");
            Instantiate(underAttackEffects, go.transform.position, Quaternion.identity, gameObject.transform.parent.parent);
        }
    }

    public void Treatment()//单体治疗
    {
        GameObject go = FindMyRole();
        go.GetComponent<RoleBase>().Myhp += myTreatment[lv - 1];
        go.GetComponent<RoleBase>().treatmentText.hpText = myTreatment[lv - 1];
        go.GetComponent<RoleBase>().treatmentAnimator.SetTrigger("Treatment");
    }

    public void Treatments(int numberTreatmen)//群体治疗
    {
        if (gameObject.CompareTag("MyRolePlane"))//我方群体治疗
        {
            if (BattlefieldMonitor.Instance.allMyRoles.Length < numberTreatmen)
            {
                numberTreatmen = BattlefieldMonitor.Instance.allMyRoles.Length;
            }
            List<GameObject> roles = new List<GameObject>();
            for (int i = 0; i < BattlefieldMonitor.Instance.allMyRoles.Length; i++)
            {
                roles.Add(BattlefieldMonitor.Instance.allMyRoles[i]);
            }
            for (int i = 0; i < numberTreatmen; i++)
            {
                int var = Random.Range(0, roles.Count);
                GameObject go = roles[var];
                roles.RemoveAt(var);
                go.GetComponent<RoleBase>().Myhp += myTreatment[lv - 1];
                go.GetComponent<RoleBase>().treatmentText.hpText = myTreatment[lv - 1];
                go.GetComponent<RoleBase>().treatmentAnimator.SetTrigger("Treatment");
            }
        }
        else if (gameObject.CompareTag("EnemysPlane"))
        {
            if (BattlefieldMonitor.Instance.allEnemys.Length < numberTreatmen)
            {
                numberTreatmen = BattlefieldMonitor.Instance.allEnemys.Length;
            }
            List<GameObject> roles = new List<GameObject>();
            for (int i = 0; i < BattlefieldMonitor.Instance.allEnemys.Length; i++)
            {
                roles.Add(BattlefieldMonitor.Instance.allEnemys[i]);
            }
            for (int i = 0; i < numberTreatmen; i++)
            {
                int var = Random.Range(0, roles.Count);
                GameObject go = roles[var];
                roles.RemoveAt(var);
                go.GetComponent<RoleBase>().Myhp += myTreatment[lv - 1];
                go.GetComponent<RoleBase>().treatmentText.hpText = myTreatment[lv - 1];
                go.GetComponent<RoleBase>().treatmentAnimator.SetTrigger("Treatment");
            }
        }
    }

    public GameObject FindMyRole()//寻找我方血量最少的一个角色
    {
        if (gameObject.CompareTag("MyRolePlane"))
        {
            GameObject go = BattlefieldMonitor.Instance.allMyRoles[0];
            float min = BattlefieldMonitor.Instance.allMyRoles[0].GetComponent<RoleBase>().hpBar.currentfill;
            for (int i = 0; i < BattlefieldMonitor.Instance.allMyRoles.Length; i++)
            {
                if (BattlefieldMonitor.Instance.allMyRoles[i].GetComponent<RoleBase>().hpBar.currentfill <= min)
                {
                    min = BattlefieldMonitor.Instance.allMyRoles[i].GetComponent<RoleBase>().hpBar.currentfill;
                    go = BattlefieldMonitor.Instance.allMyRoles[i];
                    if (i == BattlefieldMonitor.Instance.allMyRoles.Length)
                    {
                        return go;
                    }
                }
            }
            return go;
        }
        else if (gameObject.CompareTag("EnemysPlane"))
        {
            GameObject go = BattlefieldMonitor.Instance.allEnemys[0];
            float min = BattlefieldMonitor.Instance.allEnemys[0].GetComponent<RoleBase>().hpBar.currentfill;
            for (int i = 0; i < BattlefieldMonitor.Instance.allEnemys.Length; i++)
            {
                if (BattlefieldMonitor.Instance.allEnemys[i].GetComponent<RoleBase>().hpBar.currentfill <= min)
                {
                    min = BattlefieldMonitor.Instance.allEnemys[i].GetComponent<RoleBase>().hpBar.currentfill;
                    go = BattlefieldMonitor.Instance.allEnemys[i];
                    if (i == BattlefieldMonitor.Instance.allEnemys.Length)
                    {
                        return go;
                    }
                }
            }
            return go;
        }
        else
        {
            return null;
        }
    }


    public GameObject FindTheTarget()//随机锁定一个攻击对象
    {
        GameObject go;
        if (gameObject.CompareTag("MyRolePlane") && allRoles.allEnemys.Length > 0)
        {
            int randomNumber = Random.Range(0, allRoles.allEnemys.Length);
            go = allRoles.allEnemys[randomNumber];
            return go;
        }
        else if (gameObject.CompareTag("EnemysPlane") && allRoles.allMyRoles.Length > 0)
        {
            int randomNumber = Random.Range(0, allRoles.allMyRoles.Length);
            go = allRoles.allMyRoles[randomNumber];
            return go;
        }
        else
        {
            return null;
        }
    }

    public int DamageCalculation(int Dam, int yourDefense)//伤害计算
    {
        int damag;
        damag = Dam - yourDefense;
        if (damag <= 0)
        {
            damag = 1;
        }
        return damag;
    }

    public void Dead()//角色死亡
    {

        if (Myhp <= 0 && transform.CompareTag("EnemysPlane"))
        {
            UserAssetManager.Instance.AddGold(5);
            Instantiate(deadEffects, transform.position,Quaternion.identity,gameObject.transform.parent.parent);
            Destroy(this.gameObject);
        }
        else if (Myhp <= 0 && transform.CompareTag("MyRolePlane"))
        {
            Destroy(this.gameObject);
        }

    }

    public IEnumerator AttackCountdown(float time, Stat myBar)//攻击频率
    {
        float tim = 0;
        while (time > 0)
        {
            yield return new WaitForSeconds(1);
            tim++;
            myBar.CurrentValue = tim;
            time--;
        }
    }
}