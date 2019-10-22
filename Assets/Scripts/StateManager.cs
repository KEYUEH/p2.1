using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : ActorManagerInterface
{
    public float HP = 15.0f;
    public float HPmax = 15.0f;

    [Header("1sr order state flags")]
    public bool isGround;
    public bool isJump;
    public bool isFall;
    public bool isRoll;
    public bool isJab;
    public bool isAttack;
    public bool isHit;
    public bool isDie;
    public bool isBlock;
    public bool isDefense;

    [Header("2nd order state flag")]
    public bool isAllowDefense;
    public bool isImmortal;

    // Start is called before the first frame update
    void Start()
    {
        HP = HPmax;

    }

    public void AddHp(float value)
    {
        HP += value;
        HP = Mathf.Clamp(HP, 0, HPmax);
    }

    // Update is called once per frame
    void Update()
    {
        isGround = am.ac.checkState("ground");
        isJump = am.ac.checkState("jump");
        isFall = am.ac.checkState("fall");
        isRoll = am.ac.checkState("roll");
        isJab = am.ac.checkState("jab");
        isAttack = am.ac.checkStateTag("attackR") || am.ac.checkStateTag("attackL");
        isHit = am.ac.checkState("hit");
        isDie = am.ac.checkState("die");
        isBlock = am.ac.checkState("block");


        isAllowDefense = isGround || isBlock;
        isDefense = isAllowDefense && am.ac.checkState("defense1h", "defense");
        isImmortal = isRoll || isJab;
    }
}
