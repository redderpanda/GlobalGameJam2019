using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Little_Animtio_Script : MonoBehaviour {
    public GameObject to_be_animated;
    public bool triggered;
    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = to_be_animated.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (triggered)
        {
            triggered = false;
            animator.Play("Child_Running_Away");
            StartCoroutine(Stop_in_x());
        }
	}

    public IEnumerator Stop_in_x()
    {
        yield return new WaitForSeconds(0.99f);
        animator.speed = 0f;
    }
}
