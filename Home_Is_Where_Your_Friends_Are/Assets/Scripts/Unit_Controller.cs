using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Controller : MonoBehaviour {
    public float speed = 5f;
    public float jumpSpeed = 20f;
    public float airTime = 3f;
    public float floatY = 0;
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
            Jared_Take_Inputs();
        }
	}

    private void Jared_Take_Inputs()
    {
        float p_x = Planet.transform.position.x;
        float p_y = Planet.transform.position.y;
        float player_x = transform.position.x;
        float player_y = transform.position.y;

        float angleBetween = Mathf.Atan2(player_y - p_y, player_x - p_x) * 180 / Mathf.PI;
        //Debug.Log(angleBetween);
        Vector3 eul = transform.eulerAngles;
        Quaternion new_rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angleBetween - 90);
        transform.rotation = new_rot;
        if (Input.GetKey(KeyCode.D))
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
                angleBetween -= 2;
                float sin_val = Mathf.Sin(angleBetween * Mathf.PI / 180);
                float dist = Vector3.Distance(transform.position, Planet.transform.position);
                Debug.Log(dist);
                float y = dist * sin_val;
                float cos_val = Mathf.Cos(angleBetween * Mathf.PI / 180);
                float x = dist * cos_val;
                Vector3 new_pos = new Vector3(x, y, transform.position.z);
                transform.position = new_pos;
            }
        }
        if (Input.GetKey(KeyCode.A))
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

            foreach (RaycastHit2D rayHit in hit2D_d)
            {
                if (rayHit.collider.gameObject.tag == "Planet")
                {
                    will_move = false;
                    Debug.Log("Got something: Left");
                }
            }

            if (will_move)
            {
                angleBetween += 2;
                float sin_val = Mathf.Sin(angleBetween * Mathf.PI / 180);
                float dist = Vector3.Distance(transform.position, Planet.transform.position);
                Debug.Log(dist);
                float y = dist * sin_val;
                float cos_val = Mathf.Cos(angleBetween * Mathf.PI / 180);
                float x = dist * cos_val;
                Vector3 new_pos = new Vector3(x, y, transform.position.z);
                transform.position = new_pos;
            }
        }

        if (Input.GetKeyDown("w"))
        {
            if (can_jump)
            {
                transform.Translate(Vector3.up * 0.15f, Space.Self);

            }
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
