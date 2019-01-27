using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTeamMember : MonoBehaviour {
    public GameObject GameManager,newMember;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameManager.GetComponent<Team_Controller_Script>().team.Add(newMember);
        }
    }
}
