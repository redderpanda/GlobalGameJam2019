using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDogs : MonoBehaviour {
    public List<GameObject> DogList;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Found Player");
            foreach (GameObject dog in DogList)
            {
                dog.SetActive(true);
            }
        }
    }
}
