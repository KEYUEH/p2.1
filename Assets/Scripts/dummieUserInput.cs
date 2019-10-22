using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummieUserInput : UserInput
{
    // Start is called before the first frame update
    public GameObject cameraPos;
    public cameraController cc;

    /*
    IEnumerator Start()
    {
        
        print(gameObject.name);
        print(cc.lockStateAI);


        while (true)
        {
            
            yield return 0;
        }
    }
    */
    private void Start()
    {
        //Dup = 1.0f;
        //Dup = 1.0f;
        cc = cameraPos.GetComponent<cameraController>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (cc.lockStateAI)
        {
            //run = true;
            Dup = 1.0f;
            
            if (cc.attackAct)
            {
                mouseL = true;
                Dup = 0f;
            }
            else if(!cc.attackAct)
            {
                mouseL = false;
            }
        }
        else
        {
            mouseL = false;
            Dup = 0f;
        }
        UpdateDmagDvec(Dup, Dright);
    }
}
