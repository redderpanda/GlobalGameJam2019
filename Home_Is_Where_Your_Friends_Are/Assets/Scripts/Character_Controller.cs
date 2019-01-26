using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour {
    public float speed = 5f;
    public float jumpSpeed = 20f;
    public float airTime = 3f;
    public float floatY = 0;
    public GameObject Planet;
    private Rigidbody2D rigidB;
    public bool can_jump;

	// Use this for initialization
	void Start () {
        rigidB = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
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
        if(Input.GetKey(KeyCode.A))
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
        
        if (Input.GetKeyDown("w"))
        {
            if (can_jump)
            {
                transform.Translate(Vector3.up * 0.15f ,Space.Self);

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
