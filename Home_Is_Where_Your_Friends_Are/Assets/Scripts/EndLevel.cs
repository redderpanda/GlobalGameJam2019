using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour {
    public GameObject spaceship;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") || collision.CompareTag("Friend"))
        {
            spaceship.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.SetActive(false);
        }
    }
}
