using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class RoleBase : MonoBehaviour
{
    public int hp;

    public int maxHp;

    public int defense;

    public int damage;

    public float attackSpeed;



    public virtual void FindattackTarget()
    {
      
    }

    public virtual void Dead()
    {

    }
}
