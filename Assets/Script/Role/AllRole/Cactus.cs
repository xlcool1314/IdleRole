using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : RoleBase
{
    private void Start()
    {
        base.InitRoleBase();
        
    }

    private void Update() 
    {
        hpBar.CurrentValue = myhp;
        if (attackSpeedBar.currentfill == 1 && attackSpeedBar.content.fillAmount > 0.99f) 
        {
            attackSpeedBar.content.fillAmount = 0;
            attackSpeedBar.currentfill=0;
            base.Attack(myAnimator);
            base.StartCoroutine(AttackCountdown(maxAttackSpeed, attackSpeedBar));
        }
        Dead();
    }
    
}
