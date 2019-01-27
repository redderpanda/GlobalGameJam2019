using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Savage_Controller : Unit_Controller {
    public GameObject hitBox;
    public bool upsideDown = false;

	// Use this for initialization
	protected override void Start () {
        base.Start();
        hitBox = transform.GetChild(0).gameObject;
	}
	
	// Update is called once per frame
	protected override void Update () {
        if(upsideDown && can_jump)
        {
            Jump();
        }
        if(upsideDown && !can_jump)
        {
            Fake_Update();
        }
        if (!upsideDown)
        {
            base.Update();
        }
    }

    public void Fake_Update()
    {
        float p_x = Planet.transform.position.x;
        float p_y = Planet.transform.position.y;
        float player_x = transform.position.x;
        float player_y = transform.position.y;

        angleBetween = Mathf.Atan2(player_y - p_y, player_x - p_x) * 180 / Mathf.PI;
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
                float dist = Vector3.Distance(transform.position, Planet.transform.GetChild(0).transform.position);
                //Debug.Log(dist);
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
                float dist = Vector3.Distance(transform.position, Planet.transform.GetChild(0).transform.position);
                float y = dist * sin_val;
                float cos_val = Mathf.Cos(angleBetween * Mathf.PI / 180);
                float x = dist * cos_val;
                Vector3 new_pos = new Vector3(x, y, transform.position.z);
                transform.position = new_pos;
            }
        }
    }

    public IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.1f);
        grav.forceMagnitude = -50f;
        upsideDown = true;
        transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
        hitBox.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        grav.forceMagnitude = -10f;
    }
    public IEnumerator Reset()
    {
        hitBox.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        upsideDown = false;
        transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
    }

    


    public override void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            float rad = angleBetween * Mathf.PI / 180;
            Vector2 curr_up = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
            if (can_jump)
            {
                can_jump = false;
                rigidB.AddForce(curr_up * 90f);
                if (upsideDown)
                    StartCoroutine(Reset());
                else if (!upsideDown)
                    StartCoroutine(Attack());
                

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
}
