using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team_Controller_Script : MonoBehaviour {
    public List<GameObject> team;
    public GameObject camera;
    private string current_character_string;
    private GameObject current_character_obj;

    public static float[] planetGravity = new float[] { 10, 10, 10, 10, 7 };
    public static float[] planetJumpGravity = new float[] { 6, 6, 6, 6, 3 };
    public static string[] planetNames = new string[] { "Level1", "Level2", "Level3", "Level4", "Level5" };

    // Use this for initialization
    void Start () {
        current_character_string = "1";
        current_character_obj = team[0];
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("e"))
        {
            avengers_assemble();
        }

        string input = Input.inputString;

        switch (input)
        {
            case "1":
                Debug.Log("Switched to character 1");
                current_character_obj = team[0];
                Change_Character_In_Control(0);
                current_character_string = "1";
                break;
            case "2":
                Debug.Log("Switched to character 2");
                current_character_obj = team[1];
                Change_Character_In_Control(1);
                current_character_string = "2";
                break;
            case "3":
                Debug.Log("Switched to character 3");
                current_character_obj = team[2];
                Change_Character_In_Control(2);
                current_character_string = "3";
                break;
            case "4":
                Debug.Log("Switched to character 4");
                current_character_obj = team[3];
                Change_Character_In_Control(3);
                current_character_string = "4";
                break;
        }
	}

    private void Change_Character_In_Control(int list_index)
    {
        foreach(GameObject character in team)
        {
            character.GetComponent<Unit_Controller>().being_controlled = false;
            character.GetComponent<Unit_Controller>().crown.SetActive(false);
            character.gameObject.tag = "Friend";



        }

        team[list_index].GetComponent<Unit_Controller>().being_controlled = true;
        team[list_index].GetComponent<Unit_Controller>().crown.SetActive(true);
        team[list_index].gameObject.tag = "Player";
        camera.GetComponent<Camera_Follow>().Player = team[list_index];

    }

    private void avengers_assemble()
    {
        foreach(GameObject character in team)
        {
            if(character != current_character_obj)
            {
                character.transform.position = current_character_obj.transform.position;
                character.transform.rotation = current_character_obj.transform.rotation;
            }
        }
    }
}
