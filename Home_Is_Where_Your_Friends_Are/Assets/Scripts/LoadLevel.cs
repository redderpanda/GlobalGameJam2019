using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {
    public string sceneIndex;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LoadScene(sceneIndex);
        }
    }
    void LoadScene(string sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
