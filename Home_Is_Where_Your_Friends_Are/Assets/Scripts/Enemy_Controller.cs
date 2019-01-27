using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : Unit_Controller {
    public GameObject target;

	// Use this for initialization
	protected override void Start () {
        base.Start();
        target = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	protected override void Update () {
        TakePlanetRotationInToAccount();
        float diff = angleBetween - target.GetComponent<Unit_Controller>().angleBetween;
        if(diff > 0)
        {
            if (!facing_right)
            {
                facing_right = true;
                //flip
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
            angleBetween -= 0.55f / Planet.transform.GetChild(0).transform.localScale.x;
            float sin_val = Mathf.Sin(angleBetween * Mathf.PI / 180);
            float dist = Vector3.Distance(transform.position, Planet.transform.GetChild(0).transform.position);
            //Debug.Log(dist);
            float y = dist * sin_val;
            float cos_val = Mathf.Cos(angleBetween * Mathf.PI / 180);
            float x = dist * cos_val;
            Vector3 new_pos = new Vector3(x, y, transform.position.z);
            transform.position = new_pos;
        }
        else if(diff <= 0)
        {
            if (facing_right)
            {
                facing_right = false;
                //flip
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
            angleBetween += 0.55f / Planet.transform.GetChild(0).transform.localScale.x;
            float sin_val = Mathf.Sin(angleBetween * Mathf.PI / 180);
            float dist = Vector3.Distance(transform.position, Planet.transform.GetChild(0).transform.position);
            float y = dist * sin_val;
            float cos_val = Mathf.Cos(angleBetween * Mathf.PI / 180);
            float x = dist * cos_val;
            Vector3 new_pos = new Vector3(x, y, transform.position.z);
            transform.position = new_pos;
        }
        
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
