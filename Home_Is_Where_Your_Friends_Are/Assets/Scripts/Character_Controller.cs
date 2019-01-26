using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour {
    public GameObject Planet;
    public PointEffector2D grav;
    private Rigidbody2D rigidB;
    public bool can_jump;
    public float angleBetween = 0f;

	// Use this for initialization
	void Start () {
        rigidB = this.GetComponent<Rigidbody2D>();
        grav = Planet.transform.GetChild(1).GetComponent<PointEffector2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float p_x = Planet.transform.GetChild(0).transform.position.x;
        float p_y = Planet.transform.GetChild(0).transform.position.y;
        float player_x = transform.position.x;
        float player_y = transform.position.y;

        angleBetween = Mathf.Atan2(player_y - p_y, player_x - p_x) * 180 / Mathf.PI;
        Vector3 eul = transform.eulerAngles;
        Quaternion new_rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angleBetween - 90);
        transform.rotation = new_rot;
        if (Input.GetKey(KeyCode.D))
        {
            angleBetween -= 2;
            float sin_val = Mathf.Sin(angleBetween * Mathf.PI / 180);
            float dist = Vector3.Distance(transform.position, Planet.transform.GetChild(0).transform.position);
            //Debug.Log(dist);
            float y = dist * sin_val;
            float cos_val = Mathf.Cos(angleBetween * Mathf.PI / 180);
            float x = dist * cos_val;
            Vector3 new_pos = new Vector3(x, y, transform.position.z);
            transform.position = new_pos;
        }
        if(Input.GetKey(KeyCode.A))
        {
            angleBetween += 2;
            float sin_val = Mathf.Sin(angleBetween * Mathf.PI / 180);
            float dist = Vector3.Distance(transform.position, Planet.transform.GetChild(0).transform.position);
            //Debug.Log(dist);
            float y = dist * sin_val;
            float cos_val = Mathf.Cos(angleBetween * Mathf.PI / 180);
            float x = dist * cos_val;
            Vector3 new_pos = new Vector3(x, y, transform.position.z);
            transform.position = new_pos;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            float rad = angleBetween * Mathf.PI / 180;
            Vector2 curr_up = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
            if (can_jump)
            {
                rigidB.AddForce(curr_up * 90f);
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
        if(collision.gameObject.name == "Planet")
        {
            can_jump = true;
            grav.forceMagnitude = -10f;
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
