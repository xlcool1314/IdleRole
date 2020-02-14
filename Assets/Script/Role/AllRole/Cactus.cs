using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Cactus : RoleBase
{
    

    private void Start()
    {
        base.InitRoleBase();
        attackSpeedBar.currentfill=0;
        hpBar.currentfill=1;
        hpBar.Initialize(maxHp,maxHp);
        attackSpeedBar.Initialize(maxAttackSpeed,maxAttackSpeed);
        base.StartCoroutine(AttackCountdown(maxAttackSpeed, attackSpeedBar));
        lossHpText.InitLossHpText(myhp);
    }

    private void Update() 
    {
        if(attackSpeedBar.currentfill==1)
        {
            attackSpeedBar.currentfill=0;
            base.Attack(myAnimator);
            base.StartCoroutine(AttackCountdown(maxAttackSpeed, attackSpeedBar));
        }
        Dead();
    }
    
}
