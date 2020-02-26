using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class RoleBase : MonoBehaviour
{
    [SerializeField]
    private int myhp;//血量

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

    public Image mySkin;//我的皮肤

    public Image myHpBarImage;//我的血条image

    
    public int Myhp 
    { 
        get => myhp;
        set 
        {
            if(myhp>maxHp)
            {
                myhp=maxHp;
            }
            else if(myhp<0){
                myhp=0;
            }
            else{
                myhp = value;
            }
            
        }  
    }

    public void RoleUpDate()
    {
        hpBar.CurrentValue = Myhp;
        Dead();
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
            Treatment();
            StartCoroutine(AttackCountdown(maxAttackSpeed, attackSpeedBar));
        }
    }

    public void InitRoleBase() //初始化
    {
        allRoles=GameObject.FindObjectOfType<BattlefieldMonitor>();//拿到存着的所有角色
        attackSpeedBar.currentfill = 0;//初始的攻击速度为0
        hpBar.currentfill = 1;//初始的血条为满
        hpBar.Initialize(Myhp, maxHp);//初始化血条的显示
        attackSpeedBar.Initialize(maxAttackSpeed, maxAttackSpeed);//初始话攻击速度的显示
        StartCoroutine(AttackCountdown(maxAttackSpeed, attackSpeedBar));//游戏开始进行第一次的攻击频率倒计时
    }

    public virtual void Attack(Animator attackAnimator)//攻击表现
    {
        GameObject go=FindTheTarget();//找到要攻击的随机目标
        if (go != null)
        {
            go.GetComponent<RoleBase>().Myhp -= DamageCalculation(mindamage,maxdamage, go.GetComponent<RoleBase>().defense);//计算出伤害然后在血量里面减去
            go.GetComponent<RoleBase>().lossAnimator.SetTrigger("LossHp");
            go.GetComponent<RoleBase>().lossHpText.hpText = DamageCalculation(mindamage,maxdamage, go.GetComponent<RoleBase>().defense);
            attackAnimator.SetTrigger("Attack");
        }
        
    }

    public void Treatment()//治疗
    {
        GameObject go = FindMyRole();
        go.GetComponent<RoleBase>().Myhp += myTreatment;
        go.GetComponent<RoleBase>().treatmentText.hpText = myTreatment;
        go.GetComponent<RoleBase>().treatmentAnimator.SetTrigger("Treatment");
    }

    public GameObject FindMyRole()//寻找我方血量最少的角色
    {
        if (gameObject.CompareTag("MyRolePlane"))
        {
            GameObject go = BattlefieldMonitor.Instance.allMyRoles[0];
            float min = BattlefieldMonitor.Instance.allMyRoles[0].GetComponent<RoleBase>().hpBar.currentfill;
            for (int i = 0; i < BattlefieldMonitor.Instance.allMyRoles.Length; i++)
            {
                if (BattlefieldMonitor.Instance.allMyRoles[i].GetComponent<RoleBase>().hpBar.currentfill <= min)
                {
                    min=BattlefieldMonitor.Instance.allMyRoles[i].GetComponent<RoleBase>().hpBar.currentfill;
                    go = BattlefieldMonitor.Instance.allMyRoles[i];
                    if(i==BattlefieldMonitor.Instance.allMyRoles.Length){
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
                    min=BattlefieldMonitor.Instance.allEnemys[i].GetComponent<RoleBase>().hpBar.currentfill;
                    go = BattlefieldMonitor.Instance.allEnemys[i];
                    if(i==BattlefieldMonitor.Instance.allEnemys.Length)
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

    public GameObject FindTheTarget()//随机锁定一个敌人
    {
        GameObject go;
        if(gameObject.CompareTag("MyRolePlane")&&allRoles.allEnemys.Length>0)
        {
            int randomNumber=Random.Range(0,allRoles.allEnemys.Length);
            go=allRoles.allEnemys[randomNumber];
            return go;
        }
        else if (gameObject.CompareTag("EnemysPlane")&&allRoles.allMyRoles.Length>0)
        {
            int randomNumber=Random.Range(0,allRoles.allMyRoles.Length);
            go=allRoles.allMyRoles[randomNumber];
            return go;
        }
        else
        {
            return null;
        }
    }

    public int DamageCalculation(int myMinDam,int myMaxDam,int yourDefense)//伤害计算
    {
        int damag;
        damag=Random.Range(myMinDam,myMaxDam)-yourDefense;
        if (damag <= 0)
        {
            damag = 1;
        }
        return damag;
    }

    public void Dead()//角色死亡
    {
        if(Myhp<=0)
        {
            Destroy(this.gameObject);
        }
        
    }

    public IEnumerator AttackCountdown(float time,Stat myBar)//攻击频率
    {   
        float tim=0;
        while (time>0)
        {
            yield return new WaitForSeconds (1);
            tim++;
            myBar.CurrentValue=tim;
            time--;
        }
    }
}