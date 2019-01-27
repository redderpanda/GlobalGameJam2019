using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour {
    public GameObject Player;
    public float z;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float PlayerXpos = Player.transform.position.x;
        float PlayerYpos = Player.transform.position.y;
        
        transform.position = new Vector3(PlayerXpos, PlayerYpos, z);
        transform.rotation = Player.transform.rotation;

    }
}
