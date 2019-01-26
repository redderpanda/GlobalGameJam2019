using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour {
    public GameObject Planet;
    private Rigidbody2D rigidB;
    private bool can_jump;

	// Use this for initialization
	void Start () {
        rigidB = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("a"))
        {
            transform.RotateAround(Planet.transform.position, Vector3.back, -5);
        }

        if (Input.GetKey("d"))
        {
            transform.RotateAround(Planet.transform.position, Vector3.back, 5);
        }

        if (Input.GetKeyDown("w"))
        {
            if (can_jump)
            {
                Debug.DrawLine(transform.position, Planet.transform.position);
                float local_x = transform.up.x;
                float local_y = transform.up.y;
                Vector2 local_up = new Vector2(local_x, local_y);
                rigidB.AddForce(local_up * 100);
            }
        }

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Planet")
        {
            can_jump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Planet")
        {
            can_jump = false;
        }
    }
}
