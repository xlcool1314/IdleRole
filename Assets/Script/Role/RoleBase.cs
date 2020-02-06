using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleBase : MonoBehaviour
{
    public int hp;

    public int defense;

    public int damage;

    public float attackSpeed;

    public void FindattackTarget(){
        if(this.gameObject.CompareTag("MyRolePlane"))
        {
          return;
        }
    
       
    }
    


    
}
