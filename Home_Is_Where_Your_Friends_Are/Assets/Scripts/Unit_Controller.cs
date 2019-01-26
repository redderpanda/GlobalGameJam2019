using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Controller : MonoBehaviour {
    public GameObject Planet;
    private Rigidbody2D rigidB;
    private bool can_jump;
    public bool being_controlled = false;
    public bool facing_right = true;

	// Use this for initialization
	void Start () {
        rigidB = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (being_controlled)
        {
            TakeInputs();
        }
	}

    private void TakeInputs()
    {
        if (Input.GetKey("a"))
        {
            if (facing_right)
            {
                facing_right = false;
                //flip
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
            
            bool will_move = true;
            Debug.DrawLine(transform.position, transform.position + (transform.right * -0.065f), Color.green);
            RaycastHit2D[] hit2D_d = Physics2D.RaycastAll(transform.position, transform.right * -1, 0.065f);

            foreach(RaycastHit2D rayHit in hit2D_d)
            {
                if (rayHit.collider.gameObject.tag == "Planet")
                {
                    will_move = false;
                    Debug.Log("Got something: Left");
                }
            }

            if (will_move)
            {
                transform.RotateAround(Planet.transform.position, Vector3.back, -1);
            }
            
        }

        if (Input.GetKey("d"))
        {
            if (!facing_right)
            {
                facing_right = true;
                //flip
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }

            bool will_move = true;
            Debug.DrawLine(transform.position, transform.position + (transform.right * 0.065f), Color.red);
            RaycastHit2D[] hit2D_d = Physics2D.RaycastAll(transform.position, transform.right, 0.065f);

            foreach (RaycastHit2D rayHit in hit2D_d)
            {
                if (rayHit.collider.gameObject.tag == "Planet")
                {
                    will_move = false;
                    Debug.Log("Got something: Right");
                }
            }

            if (will_move)
            {
                transform.RotateAround(Planet.transform.position, Vector3.back, 1);
            }

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
                can_jump = false;
            }
        }

        float p_x = Planet.transform.position.x;
        float p_y = Planet.transform.position.y;
        float player_x = transform.position.x;
        float player_y = transform.position.y;

        float angleBetween = Mathf.Atan2(player_y - p_y, player_x - p_x) * 180 / Mathf.PI;
        //Debug.Log(angleBetween);
        Vector3 eul = transform.eulerAngles;
        Quaternion new_rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angleBetween - 90);
        transform.rotation = new_rot;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Planet")
        {
            can_jump = true;
        }
    }
}
