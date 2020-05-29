using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreatmenLowHp : AttackBase
{
    public void TreatmentOneUpDate()//单体治疗更新
    {
        if (role.attackSpeedBar.currentfill == 1 && role.attackSpeedBar.content.fillAmount > 0.99f)
        {
            role.attackSpeedBar.content.fillAmount = 0;
            role.attackSpeedBar.currentfill = 0;
            Treatment();
            StartCoroutine(AttackCountdown(role.maxAttackSpeed, role.attackSpeedBar));
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

    public override void UseSkill()
    {
        TreatmentOneUpDate();
    }
}
