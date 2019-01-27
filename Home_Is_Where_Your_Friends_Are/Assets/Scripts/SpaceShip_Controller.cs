using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip_Controller : MonoBehaviour {

    private Rigidbody2D rb2d;
    public float speed;
    public float rotSpeed;
    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Quaternion rotation = transform.rotation;//Grabs the current rotation
        float z = rotation.eulerAngles.z;
        z -= Input.GetAxis("Horizontal") * rotSpeed; //multiplies that rotation by a certain degree
        rotation = Quaternion.Euler(0, 0, z); //creates a new rotation quaternion
        transform.rotation = rotation; //feeds the new quaternion to the object

        float Vertical = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(0, Vertical * speed, 0);
        Vector3 pos = transform.position;

        pos += transform.rotation * velocity;
        transform.position = pos;
    }
}
