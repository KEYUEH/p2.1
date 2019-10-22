using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorManager : MonoBehaviour
{
    public ActorController ac;
    
    [Header("====== Auto Generate if Null ======")]
    public BattleManager bm;
    public weaponManager wm;
    public StateManager sm;
    // Start is called before the first frame update
    void Awake()
    {
        ac = GetComponent<ActorController>();
        GameObject model = ac.model;
        GameObject sensor = transform.Find("sensor").gameObject;

        bm = Bind<BattleManager>(sensor);
        wm = Bind<weaponManager>(model);
        sm = Bind<StateManager>(gameObject);
    }

    private T Bind<T>(GameObject go) where T : ActorManagerInterface
    {
        T tempInstance;
        tempInstance = go.GetComponent<T>();
        if(tempInstance == null)
        {
            tempInstance = go.AddComponent<T>();
        }
        tempInstance.am = this;
        return tempInstance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TryDoDamage()
    {


        if (sm.isImmortal)
        {
            //do nothing
        }
        else if (sm.isDefense)
        {
            //attack should be blocked
            Blocked();
        }
        else
        {
            HitOrDie();
        }
    }

    public void Blocked()
    {
        ac.IssueTrigger("block");
    }

    public void Hit()
    {
        ac.IssueTrigger("hit");
    }

    public void Die()
    {
        ac.IssueTrigger("die");
        ac.pi.inputEnabled = false;
        if(ac.camcon.lockState == true)
        {
            ac.camcon.LockUnlock();
        }
        ac.camcon.enabled = false;
    }

    public void HitOrDie()
    {
        if (sm.HP <= 0)
        {

        }
        else
        {
            sm.AddHp(-5);
            if (sm.HP > 0)
            {
                Hit();
            }
            else
            {
                Die();
            }
        }
    }
}
