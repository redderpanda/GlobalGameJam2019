using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePartsinLevel : MonoBehaviour {

    public GameObject MainPlanet, InsideBuilding, Alphabet, Gate, player, spawnpoint, camera, newFollowObject;
    public PointEffector2D newgrav;
    public bool inMain;
    public int newCamerasize;

    private void Start()
    {
        inMain = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (/*Input.GetKeyDown(KeyCode.F) &&*/ inMain)
        {
            StartCoroutine(waiting());
            MainPlanet.SetActive(false);
            InsideBuilding.SetActive(true);
            player.transform.position = spawnpoint.gameObject.transform.position;
            player.gameObject.GetComponent<Unit_Controller>().Planet = InsideBuilding;
            player.gameObject.GetComponent<Unit_Controller>().grav = newgrav;
            Alphabet.gameObject.SetActive(true);
            camera.gameObject.GetComponent<Camera_Follow>().Player = newFollowObject;
            camera.gameObject.GetComponent<Camera>().orthographicSize = newCamerasize;
            inMain = false;
        }
        //else
        //{
        //    StartCoroutine(waiting());
        //    InsideBuilding.SetActive(false);
        //    MainPlanet.SetActive(true);
        //    player.transform.position = spawnpoint.gameObject.transform.position;
        //    player.gameObject.GetComponent<Unit_Controller>().Planet = MainPlanet;
        //    player.gameObject.GetComponent<Unit_Controller>().grav = newgrav;
        //    Alphabet.gameObject.SetActive(false);
        //    InputPassword.SetActive(false);
        //    Gate.SetActive(false);
        //    camera.gameObject.GetComponent<Camera_Follow>().Player = newFollowObject;
        //    camera.gameObject.GetComponent<Camera>().orthographicSize = 5;
        //}
        

    }
    IEnumerator waiting()
    {
        yield return new WaitForSeconds(5);

    }
}
