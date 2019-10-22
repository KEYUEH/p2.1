using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class BattleManager : ActorManagerInterface
{
	private CapsuleCollider defCol;

    void Start()
	{
        defCol = GetComponent<CapsuleCollider>();
        defCol.center = Vector3.up*0.6f;
        defCol.height = 1.2f;
        defCol.radius = 0.5f;
        defCol.isTrigger = true;
	}


    
    void OnTriggerEnter(Collider col)
    {
        
        weaponController targetWc = col.GetComponentInParent<weaponController>();
        
        GameObject attacker = targetWc.wm.am.gameObject;
        
        GameObject receiver = am.gameObject;
        
        Vector3 attackingDir = receiver.transform.position - attacker.transform.position;

        float attackingAngle1 = Vector3.Angle(attacker.transform.forward, attackingDir);

        
        if (col.tag == "Weapon")
        {
            if(attackingAngle1 <= 45)
            {
                am.TryDoDamage();
            }
        }
    }
}
