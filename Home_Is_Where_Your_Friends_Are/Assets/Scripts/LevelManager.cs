﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public int currentPlanet = 0;
    GameObject A, B, C, D, E, ship;
    public Vector3[] planetSpawnPos = new Vector3[] {new Vector3(34.9f,20.4f,0f),new Vector3(56.8f,-6.3f,0f), new Vector3(86.2f,12.2f,0f)};
    public bool doOnce = false;

	// Use this for initialization
	void Awake () {
        DontDestroyOnLoad(this.gameObject);
	}

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MyScene")
        {
            A = GameObject.Find("PlanetA");
            B = GameObject.Find("PlanetB");
            C = GameObject.Find("PlanetC");
            D = GameObject.Find("PlanetD");
            E = GameObject.Find("PlanetE");
            ship = GameObject.FindGameObjectWithTag("Player");
            switch (currentPlanet)
            {
                case (0):
                    
                    A.GetComponent<CircleCollider2D>().enabled = false;
                    B.transform.GetChild(0).gameObject.SetActive(true);
                    C.GetComponent<CircleCollider2D>().enabled = false;
                    D.GetComponent<CircleCollider2D>().enabled = false;
                    E.GetComponent<CircleCollider2D>().enabled = false;
                    break;
                case (1):
                    if (!doOnce)
                    {
                        doOnce = true;
                        ship.transform.position = planetSpawnPos[0];
                    }
                    A.GetComponent<CircleCollider2D>().enabled = false;
                    B.GetComponent<CircleCollider2D>().enabled = false;
                    C.transform.GetChild(0).gameObject.SetActive(true);
                    D.GetComponent<CircleCollider2D>().enabled = false;
                    E.GetComponent<CircleCollider2D>().enabled = false;
                    break;
                case (2):
                    if (!doOnce)
                    {
                        doOnce = true;
                        ship.transform.position = planetSpawnPos[1];
                    }
                    A.GetComponent<CircleCollider2D>().enabled = false;
                    B.GetComponent<CircleCollider2D>().enabled = false;
                    C.GetComponent<CircleCollider2D>().enabled = false;
                    D.transform.GetChild(0).gameObject.SetActive(true);
                    E.GetComponent<CircleCollider2D>().enabled = false;
                    break;
                case (3):
                    if (!doOnce)
                    {
                        doOnce = true;
                        ship.transform.position = planetSpawnPos[2];
                    }
                    A.GetComponent<CircleCollider2D>().enabled = false;
                    B.GetComponent<CircleCollider2D>().enabled = false;
                    C.GetComponent<CircleCollider2D>().enabled = false;
                    D.GetComponent<CircleCollider2D>().enabled = false;
                    E.transform.GetChild(0).gameObject.SetActive(true);
                    break;
            }
        }
    }
}
