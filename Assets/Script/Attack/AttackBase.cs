using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackBase : SingletonMono<AttackBase>
{
    public RoleBase role;//实例化角色信息

    public abstract void UseSkill();
    private void Awake()
    {
        role = transform.GetComponent<RoleBase>();
    }
    public int DamageCalculation(int Dam, int yourDefense)//伤害计算
    {
        int damag;
        damag = Dam - yourDefense;
        if (damag <= 0)
        {
            damag = 1;
        }
        return damag;
    }

    public void Dead()//角色死亡
    {
        if (role.Myhp <= 0 && transform.CompareTag("EnemysPlane") && UserAssetManager.Instance.IsFirstGame() == false && role.isDead == false)
        {
            UserAssetManager.Instance.AddGold(role.dropMoneys);
            Instantiate(role.deadEffects, transform.position, Quaternion.identity, gameObject.transform.parent.parent);
            Destroy(this.gameObject, 0.5f);
            role.isDead = true;
        }
        else if (role.Myhp <= 0 && transform.CompareTag("MyRolePlane") && role.isDead == false)
        {
            Destroy(this.gameObject, 0.5f);
            role.isDead = true;
        }
    }

    public IEnumerator AttackCountdown(float time, Stat myBar)//攻击频率
    {
        float tim = 0;
        while (time > 0)
        {
            yield return new WaitForSeconds(1);
            tim++;
            myBar.CurrentValue = tim;
            time--;
        }
    }

}
