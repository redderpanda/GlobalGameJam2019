using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Controller : MonoBehaviour {
    public float speed = 5f;
    public float jumpSpeed = 20f;
    public float airTime = 3f;
    public float floatY = 0;
    public GameObject Planet;
    public PointEffector2D grav;
    public Rigidbody2D rigidB;
    public bool can_jump;
    public bool being_controlled = false;
    public bool facing_right = true;
    public float angleBetween = 0f;

    


    public Animator anim;

    // Use this for initialization
    protected virtual void Start () {
        rigidB = this.GetComponent<Rigidbody2D>();
        Planet = GameObject.Find("OutterShell");
        grav = Planet.transform.GetChild(1).GetComponent<PointEffector2D>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	protected virtual void Update () {
        TakePlanetRotationInToAccount();
        if (being_controlled)
        {
            Jared_Take_Inputs();
        }
	}

    public void TakePlanetRotationInToAccount()
    {
        float p_x = Planet.transform.position.x;
        float p_y = Planet.transform.position.y;
        float player_x = transform.position.x;
        float player_y = transform.position.y;

        angleBetween = Mathf.Atan2(player_y - p_y, player_x - p_x) * 180 / Mathf.PI;
        Vector3 eul = transform.eulerAngles;
        Quaternion new_rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angleBetween - 90);
        transform.rotation = new_rot;
    }

    public virtual void Jared_Take_Inputs()
    {
        Jump();
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("Moving", true);
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
                if (rayHit.collider.gameObject.tag == "Planet" || rayHit.collider.gameObject.tag == "Friend")
                {
                    will_move = false;
                    Debug.Log("Got something: Right");
                }
                
            }

            if (will_move)
            {
                angleBetween -= 10 / Planet.transform.GetChild(0).transform.localScale.x;
                float sin_val = Mathf.Sin(angleBetween * Mathf.PI / 180);
                float dist = Vector3.Distance(transform.position, Planet.transform.GetChild(0).transform.position);
                //Debug.Log(dist);
                float y = dist * sin_val;
                float cos_val = Mathf.Cos(angleBetween * Mathf.PI / 180);
                float x = dist * cos_val;
                Vector3 new_pos = new Vector3(x, y, transform.position.z);
                transform.position = new_pos;
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("Moving", true);
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
                if (rayHit.collider.gameObject.tag == "Planet" || rayHit.collider.gameObject.tag == "Friend")
                {
                    will_move = false;
                    Debug.Log("Got something: Left");
                }
            }

            if (will_move)
            {
                angleBetween += 10 / Planet.transform.GetChild(0).transform.localScale.x;
                float sin_val = Mathf.Sin(angleBetween * Mathf.PI / 180);
                float dist = Vector3.Distance(transform.position, Planet.transform.GetChild(0).transform.position);
                float y = dist * sin_val;
                float cos_val = Mathf.Cos(angleBetween * Mathf.PI / 180);
                float x = dist * cos_val;
                Vector3 new_pos = new Vector3(x, y, transform.position.z);
                transform.position = new_pos;
            }
        }

        else
        {
            anim.SetBool("Moving", false);
        }
    }

    public virtual void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float rad = angleBetween * Mathf.PI / 180;
            Vector2 curr_up = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
            if (can_jump)
            {
                can_jump = false;
                rigidB.AddForce(curr_up * 80f);
            }
        }
        if (Input.GetKey(KeyCode.W) && !can_jump)
        {
            grav.forceMagnitude = -6f;
        }
        if (Input.GetKeyUp(KeyCode.W) && !can_jump)
        {
            grav.forceMagnitude = -10f;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Planet" || collision.gameObject.tag == "Friend")
        {
            can_jump = true;
            grav.forceMagnitude = -10f;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Planet")
        {
            can_jump = false;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Planet")
        {
            can_jump = true;
            grav.forceMagnitude = -10f;
        }
    }

}
