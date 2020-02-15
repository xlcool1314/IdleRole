using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RoleBase : MonoBehaviour
{
    public int myhp;//血量

    public int maxHp;//最大血量

    public int defense;//防御

    public int damage;//攻击力

    public float maxAttackSpeed;//最大的的攻击间隔

    public Animator myAnimator;//动画控制器

    public GameObject attackEffects;//攻击特效

    public GameObject underAttackEffects;//受击特效

    public GameObject deadEffects;//死亡特效

    public BattlefieldMonitor allRoles;//所有角色

    public Stat hpBar;//血条

    public Stat attackSpeedBar;//攻击频率条

    public LossHp lossHpText;

    public void InitRoleBase() //初始化
    {
        allRoles=GameObject.FindObjectOfType<BattlefieldMonitor>();//拿到存着的所有角色
        attackSpeedBar.currentfill = 0;//初始的攻击速度为0
        hpBar.currentfill = 1;//初始的血条为满
        hpBar.Initialize(myhp, maxHp);//初始化血条的显示
        attackSpeedBar.Initialize(maxAttackSpeed, maxAttackSpeed);//初始话攻击速度的显示
        StartCoroutine(AttackCountdown(maxAttackSpeed, attackSpeedBar));//游戏开始进行第一次的攻击频率倒计时
    }

    public virtual void Attack(Animator attackAnimator)//攻击表现
    {
        GameObject go=FindTheTarget();//找到要攻击的随机目标
        go.GetComponent<RoleBase>().myhp -= DamageCalculation(damage, go.GetComponent<RoleBase>().defense);//计算出伤害然后在血量里面减去
        go.GetComponent<RoleBase>().lossHpText.gameObject.SetActive(true);
        go.GetComponent<RoleBase>().lossHpText.hpText = DamageCalculation(damage, go.GetComponent<RoleBase>().defense);
        attackAnimator.SetTrigger("Attack");
    }

    public GameObject FindTheTarget()//随机锁定一个敌人
    {
        GameObject go;
        if(gameObject.CompareTag("MyRolePlane"))
        {
            int randomNumber=Random.Range(0,allRoles.allEnemys.Length);
            go=allRoles.allEnemys[randomNumber];
            return go;
        }
        else if (gameObject.CompareTag("EnemysPlane"))
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

    public int DamageCalculation(int myDamage,int yourDefense)//伤害计算
    {
        int damag;
        damag=myDamage-yourDefense;
        return damag;
    }

    public void Dead()//角色死亡
    {
        if(myhp<=0)
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