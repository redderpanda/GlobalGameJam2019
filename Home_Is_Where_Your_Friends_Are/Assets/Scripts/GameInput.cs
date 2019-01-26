using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInput : MonoBehaviour {

    private InputField input;
    public GameObject wall;
    private void Awake()
    {
        input = GameObject.Find("InputField").GetComponent<InputField>();
    }

    public void GetInput(string password)
    {
        Debug.Log("Password: " + password);
        input.text = "";
        if(password.ToLower() == "open")
        {
            wall.SetActive(false);
        }
    }
}
