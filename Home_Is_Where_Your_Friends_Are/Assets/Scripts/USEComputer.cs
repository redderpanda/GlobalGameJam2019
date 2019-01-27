using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USEComputer : MonoBehaviour {
    public GameObject ComputerCanvas;//input canvas

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            ComputerCanvas.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            ComputerCanvas.SetActive(false);
    }
}
