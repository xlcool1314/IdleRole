using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTreatmens : AttackBase
{
    public override void UseSkill()
    {
        TreatmentUpDate();
    }

    public void TreatmentUpDate()//治疗更新
    {
        if (role.attackSpeedBar.currentfill == 1 && role.attackSpeedBar.content.fillAmount > 0.99f)
        {
            role.attackSpeedBar.content.fillAmount = 0;
            role.attackSpeedBar.currentfill = 0;
            Treatments(role.numberTreatmens);
            StartCoroutine(AttackCountdown(role.maxAttackSpeed, role.attackSpeedBar));
        }
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
                go.GetComponent<RoleBase>().Myhp += role.myTreatment[role.lv - 1];
                go.GetComponent<RoleBase>().treatmentText.hpText = role.myTreatment[role.lv - 1];
                go.GetComponent<RoleBase>().treatmentAnimator.SetTrigger("Treatment");
                Instantiate(role.attackEffects, go.transform.position, Quaternion.identity, transform.parent.parent);
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
                go.GetComponent<RoleBase>().Myhp += role.myTreatment[role.lv - 1];
                go.GetComponent<RoleBase>().treatmentText.hpText = role.myTreatment[role.lv - 1];
                go.GetComponent<RoleBase>().treatmentAnimator.SetTrigger("Treatment");
                Instantiate(role.attackEffects, go.transform.position, Quaternion.identity, transform.parent.parent);
            }
        }
    }

}
