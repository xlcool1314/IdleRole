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

    public float maxAttackSpeed;

    public Animator myAnimator;

    public GameObject attackEffects;

    public GameObject underAttack;



    public virtual void FindattackTarget()
    {
      
    }

    public virtual void Dead()
    {
        Destroy(gameObject);

    }

    public IEnumerator AttackCountdown(float time,Stat myBar)
    {   float tim=0;
        while (time>0)
        {
            yield return new WaitForSeconds (1);
            tim++;
            myBar.CurrentValue=tim;
            Debug.Log(tim);
            time--;
        }
    }
}