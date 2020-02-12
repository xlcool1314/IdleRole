using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class RoleBase : MonoBehaviour
{
    public int hp;//血量

    public int maxHp;//最大血量

    public int defense;//防御

    public int damage;//攻击力

    public float maxAttackSpeed;//最大的的攻击间隔

    public Animator myAnimator;//动画控制器

    public GameObject attackEffects;//攻击特效

    public GameObject underAttackEffects;//受击特效

    public GameObject deadEffects;//死亡特效

    public BattlefieldMonitor allRoles;//所有角色

    private void Start() 
    {
        allRoles=GameObject.FindObjectOfType<BattlefieldMonitor>();
    }

    public virtual void Attack(Animator attackAnimator)
    {
        attackAnimator.SetTrigger("Attack");
        
    }

    public void Dead()//角色死亡
    {
        Destroy(this.gameObject);
    }

    public IEnumerator AttackCountdown(float time,Stat myBar)//攻击频率
    {   
        float tim=0;
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