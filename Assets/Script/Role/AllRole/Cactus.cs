using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : RoleBase
{
    public Stat hpBar;

    public Stat attackSpeed;

    private void Start()
    {
        base.InitRoleBase();
        attackSpeed.currentfill=0;
        hpBar.currentfill=1;
        hpBar.Initialize(hp,maxHp);
        attackSpeed.Initialize(maxAttackSpeed,maxAttackSpeed);
        base.StartCoroutine(AttackCountdown(maxAttackSpeed,attackSpeed));
    }

    private void Update() 
    {
        if(attackSpeed.currentfill==1)
        {
            attackSpeed.currentfill=0;
            base.Attack(myAnimator);
            base.StartCoroutine(AttackCountdown(maxAttackSpeed,attackSpeed));
        }
        Dead();
    }
    
}
