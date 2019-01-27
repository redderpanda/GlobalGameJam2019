using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brink_To : MonoBehaviour {

    public GameObject[] Characters;
    public GameObject place_to_take;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("-----------------------------------------");
        if (collision.collider.gameObject.tag == "Friend" || collision.collider.gameObject.tag == "Player")
        {
            bring_to_object_position();
        }
    }

    public void bring_to_object_position()
    {
        StartCoroutine(show_portal());
        foreach(GameObject character in Characters)
        {
            character.transform.position = place_to_take.transform.position;
        }

    }

    public IEnumerator show_portal()
    {
        place_to_take.SetActive(true);
        yield return new WaitForSeconds(1f);
        place_to_take.SetActive(false);
    }

}
