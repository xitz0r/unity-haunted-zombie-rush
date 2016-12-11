using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private Animator animator;
    private bool jump;
    private Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
        this.animator = GetComponent<Animator>();
        this.jump = false;
        this.rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            animator.Play("Jump");
            this.jump = true;
            this.rigidbody.useGravity = true;
        }
	}

    void FixedUpdate()
    {
        if (this.jump)
        {
            this.jump = false;
            this.rigidbody.velocity = Vector3.zero;
            this.rigidbody.AddForce(100f * Vector3.up, ForceMode.Impulse);
        }
    }
}
