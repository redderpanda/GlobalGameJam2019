using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInput : MonoBehaviour {

    private InputField input;
    public GameObject wall;
    public GameObject textaccepted;
    public GameObject entrance;
    private void Awake()
    {
        input = GameObject.Find("InputsField").GetComponentInChildren<InputField>();
    }

    public void GetInput(string password)
    {
        Debug.Log("Password: " + password);
        if (password.ToLower() == "open")
        {
            textaccepted.SetActive(true);
            wall.SetActive(false);
            entrance.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            input.text = "";
        }
    }
}
