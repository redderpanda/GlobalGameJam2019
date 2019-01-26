using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Best_Friend_Controller : Unit_Controller {
    public bool frozen = false;

	// Use this for initialization
	protected override void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	protected override void Update () {
        if (being_controlled)
        {
            if (frozen)
            {
                Freeze();
            }
            else
            {

                base.Update();
                Freeze();
            }
        }
        
	}

    public void Freeze()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            frozen = !frozen;
            if(frozen)
            {
                rigidB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                
            }
            else
            {
                rigidB.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
        
    }
}
