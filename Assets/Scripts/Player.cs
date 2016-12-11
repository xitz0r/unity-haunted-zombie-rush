using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private Animator animator;
    private bool jump;
    private Rigidbody rigidbody;
    [SerializeField] private AudioClip sfxJump;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        this.animator = GetComponent<Animator>();
        this.jump = false;
        this.rigidbody = GetComponent<Rigidbody>();
        this.audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            animator.Play("Jump");
            this.audioSource.PlayOneShot(this.sfxJump);
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
