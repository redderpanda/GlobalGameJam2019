﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInput : MonoBehaviour {

    private InputField input;
    public GameObject wall;
    public GameObject textaccepted;
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
        }
        else
        {
            input.text = "";
        }
    }
}
