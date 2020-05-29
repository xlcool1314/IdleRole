using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttack : AttackBase
{
    public override void UseSkill()
    {
        AttackUpDate();
    }

    public void AttackUpDate()//攻击伤害更新
    {
        if (role.attackSpeedBar.currentfill == 1 && role.attackSpeedBar.content.fillAmount > 0.99f)
        {
            Attack(role.myAnimator);
            role.attackSpeedBar.content.fillAmount = 0;
            role.attackSpeedBar.currentfill = 0;
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
}
