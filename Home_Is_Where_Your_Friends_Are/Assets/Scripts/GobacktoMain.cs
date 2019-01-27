using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GobacktoMain : MonoBehaviour {
    public GameObject MainPlanet, InsideBuilding, Alphabet, InputPassword, Gate, player, spawnpoint, camera, newFollowObject, entrance;
    public PointEffector2D newgrav;
    private void OnTriggerStay2D(Collider2D collision)
    {
        //if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(waiting());
            InsideBuilding.SetActive(false);
            MainPlanet.SetActive(true);
            player.transform.position = spawnpoint.gameObject.transform.position;
            player.gameObject.GetComponent<Unit_Controller>().Planet = MainPlanet;
            player.gameObject.GetComponent<Unit_Controller>().grav = newgrav;
            Alphabet.gameObject.SetActive(false);
            InputPassword.SetActive(false);
            Gate.SetActive(false);
            camera.gameObject.GetComponent<Camera_Follow>().Player = newFollowObject;
            camera.gameObject.GetComponent<Camera>().orthographicSize = 1;
            entrance.gameObject.GetComponent<ChangePartsinLevel>().inMain = true;
        }
    }

    IEnumerator waiting()
    {
        yield return new WaitForSeconds(5);

    }
}
