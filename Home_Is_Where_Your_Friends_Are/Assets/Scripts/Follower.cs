using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour {
    
    public Transform leader;
    public float followSharpness = 0.05f;
    public bool isJumping = false;

    void LateUpdate()
    {
        float p_x = leader.GetComponent<Character_Controller>().Planet.transform.position.x;
        float p_y = leader.GetComponent<Character_Controller>().Planet.transform.position.y;
        float player_x = transform.position.x;
        float player_y = transform.position.y;

        float angleBetween = Mathf.Atan2(player_y - p_y, player_x - p_x) * 180 / Mathf.PI;
        //Debug.Log(angleBetween);
        Vector3 eul = transform.eulerAngles;
        Quaternion new_rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angleBetween - 90);
        transform.rotation = new_rot;
        transform.position += (leader.position - transform.position) * followSharpness;
        if(!leader.GetComponent<Character_Controller>().can_jump && !isJumping)
        {
            transform.Translate(Vector3.up * 0.04f, Space.Self);
        }
    }
}
