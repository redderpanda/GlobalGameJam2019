using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Little_Boy_Trigger : MonoBehaviour {
    public GameObject Savage_Family;
    public GameObject Post_Touch_Text;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Friend" || collision.gameObject.tag == "Player")
        {
            Savage_Family.SetActive(true);
            Post_Touch_Text.GetComponent<Type_Writer_Text>().start_now = true;
        }
    }
}
