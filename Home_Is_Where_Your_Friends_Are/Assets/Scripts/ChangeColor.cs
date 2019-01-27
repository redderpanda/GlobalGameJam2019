using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {
    public GameObject sprite;

    private void Start()
    {
        ColorChanger();
    }
    void ColorChanger()
    {
        SpriteRenderer renderer = sprite.GetComponent<SpriteRenderer>();
        renderer.material.color = new Color(0.6f, 0.3f, 0.6f, 1f); // Set to opaque gray
    }
}
