using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBackHp : AttackBase
{
    public override void UseSkill()
    {
        AttackBackHps();
    }

    public void AttackBackHps()//攻击单体回血
    {
        if (role.attackSpeedBar.currentfill == 1 && role.attackSpeedBar.content.fillAmount > 0.99f)
        {
            role.attackSpeedBar.content.fillAmount = 0;
            role.attackSpeedBar.currentfill = 0;
            Attack(role.myAnimator);
            Treatment();
            StartCoroutine(AttackCountdown(role.maxAttackSpeed, role.attackSpeedBar));
        }
    }
    public GameObject FindTheTarget()//随机锁定一个攻击对象
    {
        GameObject go;
        if (gameObject.CompareTag("MyRolePlane") && role.allRoles.allEnemys.Length > 0)
        {
            int randomNumber = Random.Range(0, role.allRoles.allEnemys.Length);
            go = role.allRoles.allEnemys[randomNumber];
            return go;
        }
        else if (gameObject.CompareTag("EnemysPlane") && role.allRoles.allMyRoles.Length > 0)
        {
            int randomNumber = Random.Range(0, role.allRoles.allMyRoles.Length);
            go = role.allRoles.allMyRoles[randomNumber];
            return go;
        }
        else
        {
            return null;
        }
    }

    public virtual void Attack(Animator attackAnimator)//单体攻击相关
    {
        GameObject go = FindTheTarget();//找到要攻击的随机目标
        if (go != null)
        {
            go.GetComponent<RoleBase>().Myhp -= DamageCalculation(role.damage[role.lv - 1], go.GetComponent<RoleBase>().defense[role.lv - 1]);//计算出伤害然后在血量里面减去
            go.GetComponent<RoleBase>().lossAnimator.SetTrigger("LossHp");
            go.GetComponent<RoleBase>().lossHpText.hpText = DamageCalculation(role.damage[role.lv - 1], go.GetComponent<RoleBase>().defense[role.lv - 1]);
            attackAnimator.SetTrigger("Attack");
            SoundManager.Instance.PlaySound("Hit02");
            go.GetComponent<RoleBase>().myAnimator.SetTrigger("numberAttack");
            Instantiate(role.underAttackEffects, go.transform.position, Quaternion.identity, transform.parent.parent);
        }
    }

    public void Treatment()//单体治疗
    {
        GameObject go = FindMyRole();
        go.GetComponent<RoleBase>().Myhp += role.myTreatment[role.lv - 1];
        go.GetComponent<RoleBase>().treatmentText.hpText = role.myTreatment[role.lv - 1];
        go.GetComponent<RoleBase>().treatmentAnimator.SetTrigger("Treatment");
        Instantiate(role.attackEffects, go.transform.position, Quaternion.identity, transform.parent.parent);
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
}
