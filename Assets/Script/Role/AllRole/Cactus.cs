using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : RoleBase
{
    public Stat hpBar;

    public Stat attackSpeed;

    private void Start()
    {
        attackSpeed.currentfill=0;
        hpBar.currentfill=1;
        hpBar.Initialize(maxHp,maxHp);
        attackSpeed.Initialize(maxAttackSpeed,maxAttackSpeed);
        base.StartCoroutine(AttackCountdown(maxAttackSpeed,attackSpeed));
    }
}
