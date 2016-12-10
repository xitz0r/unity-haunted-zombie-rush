using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private Animator animator;

	// Use this for initialization
	void Start () {
        this.animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
            animator.Play("Jump");
	}
}
