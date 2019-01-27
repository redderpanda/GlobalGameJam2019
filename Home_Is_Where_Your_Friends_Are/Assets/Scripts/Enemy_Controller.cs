using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : Unit_Controller {

	// Use this for initialization
	protected override void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	protected override void Update () {
        TakePlanetRotationInToAccount();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("died");
            float rad = collision.gameObject.GetComponentInParent<Unit_Controller>().angleBetween * Mathf.PI / 180;
            Vector2 curr_up = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
            collision.gameObject.GetComponentInParent<Unit_Controller>().rigidB.AddForce(curr_up * 80f);
            Destroy(this.gameObject);
        }
    }
}
