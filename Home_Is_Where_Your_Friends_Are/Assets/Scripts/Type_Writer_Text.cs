using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Type_Writer_Text : MonoBehaviour {
    public bool start_now;
    private bool initial_setup;
    public GameObject text_chapter_object;
    public GameObject Text_Box_Object;
    public GameObject Name_Box_Paret_Object;
    public GameObject writting_text_obj;
    private Text writting_text;
    public GameObject Name_Box_Left;
    public GameObject Name_Box_L_Background;
    private Text name_left_text;
    public GameObject Name_Box_Right;
    public GameObject Name_Box_R_Background;
    private Text name_right_text;
    public GameObject[] Character_Portraits;
    public List<GameObject> relevant_canvases;
    public GameObject Press_e_canvas;


    //public string[] Dialog_List;
    private List<Dialog_Class> Dialog_List;
    private bool text_writting;
    private string current_text;
    private string final_text;
    private int text_cursor;
    private int dialog_cursor;
    private bool text_over;
    public List<char> half_stop_characters;
    public List<char> full_stop_characters;

    public GameObject to_be_trigger;
    public GameObject team_controller;

    public List<AudioSource> Voice_List;
    public AudioSource Text_Type_Sound;

    public GameObject[] unit_list;
    public bool finished;
    //should create a dialog class with the ability to give a player icon, name, side of the dialog window, and the current dialog
    //Add "ugh" sound to play for each character added, or at least each word

	// Use this for initialization
	void Start () {
        Press_e_canvas.SetActive(false);
        Hide_Text_Sequence();
        initial_setup = true;
        finished = false;
    }

    // Update is called once per frame
    void Update() {
        if (!finished)
        {


            if (start_now)
            {
                Take_Away_Control();
                if (initial_setup)
                {
                    initial_setup = false;
                    writting_text = writting_text_obj.GetComponent<Text>();
                    name_left_text = Name_Box_Left.GetComponent<Text>();
                    name_right_text = Name_Box_Right.GetComponent<Text>();
                    text_writting = false;
                    text_cursor = 0;
                    dialog_cursor = 0;
                    text_over = false;


                    bring_up_text_box();
                    Name_Box_Paret_Object.SetActive(true);
                    activate_containers();
                    Dialog_List = text_chapter_object.GetComponent<Dialog_Chapter_Container>().Dialogue_Container;
                }
                if (!text_over)
                {
                    if (!text_writting)
                    {
                        Debug.Log("Text_Writing");
                        StartCoroutine(write_text());
                    }
                }
                else
                {
                    if (Input.GetKeyDown("e"))
                    {
                        //End Text Sequence, or advance to next scene
                        Hide_Text_Sequence();
                        trigger_event();
                        Grant_Control();
                        finished = true;
                    }
                }
            }
        }
	}

    public IEnumerator write_text()
    {
        text_writting = true;
        current_text = "";
        text_cursor = 0;
        grey_active_Icons();
        
        final_text = Dialog_List[dialog_cursor].Dialogue;

        if(Dialog_List[dialog_cursor].Left_or_Right == true)
        {
            List<Dialog_Class> Dialogs_Before_This = Dialog_List.GetRange(0, dialog_cursor);
            foreach(Dialog_Class DC in Dialog_List)
            {
                DC.Icon.SetActive(false);
                DC.Icon_R.SetActive(false);
            }
            Name_Box_L_Background.SetActive(false);
            Name_Box_R_Background.SetActive(true);
            Dialog_List[dialog_cursor].Icon_R.SetActive(true);
            Dialog_List[dialog_cursor].Icon.SetActive(true);
            Dialog_List[dialog_cursor].Icon_R.GetComponent<Image>().color = Color.white;
            name_right_text.text = Dialog_List[dialog_cursor].Character_name;
        }
        else
        {
            List<Dialog_Class> Dialogs_Before_This = Dialog_List.GetRange(0, dialog_cursor);
            foreach (Dialog_Class DC in Dialog_List)
            {
                DC.Icon.SetActive(false);
                DC.Icon_R.SetActive(false);
            }
            Name_Box_R_Background.SetActive(false);
            Name_Box_L_Background.SetActive(true);
            Dialog_List[dialog_cursor].Icon.SetActive(true);
            Dialog_List[dialog_cursor].Icon_R.SetActive(true);
            Dialog_List[dialog_cursor].Icon.GetComponent<Image>().color = Color.white;
            name_left_text.text = Dialog_List[dialog_cursor].Character_name;
        }

        while (!current_text.Equals(final_text))
        {
            current_text += final_text[text_cursor];
            writting_text.text = current_text;

            Voice_List[Dialog_List[dialog_cursor].Voice_Number].Play();

            if (Input.GetKey("e"))
            {
                yield return new WaitForSeconds(0.02f);
            }
            else
            {
                if (half_stop_characters.Contains(final_text[text_cursor]))
                {
                    yield return new WaitForSeconds(0.1f);
                }
                else if (full_stop_characters.Contains(final_text[text_cursor]))
                {
                    yield return new WaitForSeconds(0.2f);
                }
                else
                {
                    yield return new WaitForSeconds(0.05f);
                }
            }

            text_cursor += 1;
        }

        Debug.Log("moved to next dialog");
        dialog_cursor += 1;

        if (Dialog_List.Count <= dialog_cursor)
        {
            //stop
            Debug.Log("Stopped");
            text_over = true;
        }
        //should add a button check here to move on when advance button is pressed
        //go to next dialog piece

        bool waiting_for_input = true;
        Press_e_canvas.SetActive(true);
        while (waiting_for_input)
        {
            if (Input.GetKeyDown("e"))
            {
                waiting_for_input = false;
                Press_e_canvas.SetActive(false);
                text_writting = false;
            }
            else
            {
                yield return null;
            }
        }
    }

    public void Hide_Text_Sequence()
    {
        foreach(GameObject canvas in relevant_canvases)
        {
            canvas.SetActive(false);
        }
        Name_Box_R_Background.SetActive(false);
        Name_Box_L_Background.SetActive(false);
    }

    public void grey_active_Icons()
    {
        foreach(GameObject icon_obj in Character_Portraits)
        {
            icon_obj.GetComponent<Image>().color = Color.grey;
        }
    }

    public void bring_up_text_box()
    {
        Text_Box_Object.SetActive(true);
    }

    public void activate_containers()
    {
        foreach (GameObject canvas in relevant_canvases)
        {
            canvas.SetActive(true);
        }
    }

    public void trigger_event()
    {
        if(to_be_trigger != null)
        {
            
            to_be_trigger.GetComponent<Little_Animtio_Script>().triggered = true;
        }
        
    }

    public void Grant_Control()
    {
        if(team_controller != null)
        {
            team_controller.SetActive(true);
        }
    }

    public void Take_Away_Control()
    {
        foreach(GameObject unit in unit_list)
        {
            unit.GetComponent<Unit_Controller>().being_controlled = false;
            team_controller.SetActive(false);
        }
    }
}
