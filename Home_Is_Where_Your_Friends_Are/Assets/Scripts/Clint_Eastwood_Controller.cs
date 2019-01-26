using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clint_Eastwood_Controller : Unit_Controller {
    public GameObject hatTop;
    public float maxHeight = 5;
    public float minHeight = 1;
    public float hatMin = 4.0f;
    public float hatMax = 7.5f;
    public float hatSpeed = 5f;
    public float hatPosSpeed = 4.25f;
    public bool wentUp = false;

	// Use this for initialization
	protected override void Start () {
        base.Start();
        hatTop = transform.GetChild(1).gameObject;
	}
	
	// Update is called once per frame
	protected override void Update () {
        if (being_controlled)
        {
            base.Update();
            HatGrowth();
        }
    }

    public void HatGrowth()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            wentUp = !wentUp;
        }
        if(Input.GetKey(KeyCode.Q) && wentUp)
        {
            float scale_y = hatTop.transform.localScale.y + (hatSpeed * Time.deltaTime);
            float pos_y = hatTop.transform.localPosition.y + (hatPosSpeed * Time.deltaTime);

            hatTop.transform.localScale = new Vector3(hatTop.transform.localScale.x, Mathf.Clamp(scale_y,minHeight,maxHeight), hatTop.transform.localScale.z);
            hatTop.transform.localPosition = new Vector3(hatTop.transform.localPosition.x, Mathf.Clamp(pos_y, hatMin, hatMax), hatTop.transform.localPosition.z);
        }
        if (Input.GetKey(KeyCode.Q) && !wentUp)
        {
            float scale_y = hatTop.transform.localScale.y - (hatSpeed * Time.deltaTime);
            float pos_y = hatTop.transform.localPosition.y - (hatPosSpeed * Time.deltaTime);

            hatTop.transform.localScale = new Vector3(hatTop.transform.localScale.x, Mathf.Clamp(scale_y, minHeight, maxHeight), hatTop.transform.localScale.z);
            hatTop.transform.localPosition = new Vector3(hatTop.transform.localPosition.x, Mathf.Clamp(pos_y, hatMin, hatMax), hatTop.transform.localPosition.z);
        }
    }

}
