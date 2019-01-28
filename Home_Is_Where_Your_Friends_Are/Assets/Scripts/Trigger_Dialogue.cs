using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Dialogue : MonoBehaviour {

    public GameObject Text_Controller;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Friend")
        {
            Text_Controller.GetComponent<Type_Writer_Text>().start_now = true;
        }
        
    }
}
