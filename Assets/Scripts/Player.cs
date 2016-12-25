using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;

public class Player : MonoBehaviour {

    private Animator animator;
    private bool jump;
    private Rigidbody rigidBody;
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip sfxJump;
    [SerializeField]
    private AudioClip sfxDeath;
    
    void Awake()
    {
        Assert.IsNotNull(this.sfxJump);
        Assert.IsNotNull(this.sfxDeath);
    }

	// Use this for initialization
	void Start () {
        this.animator = GetComponent<Animator>();
        this.jump = false;
        this.rigidBody = GetComponent<Rigidbody>();
        this.audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!GameManager.gameManager.IsGameOver && Input.GetMouseButtonDown(0) && GameManager.gameManager.IsGamePlaying)
        {
            GameManager.gameManager.PlayerStartedGame();
            animator.Play("Jump");
            this.audioSource.PlayOneShot(this.sfxJump);
            this.jump = true;
            this.rigidBody.useGravity = true;
        }
	}

    void FixedUpdate()
    {
        if (this.jump)
        {
            this.jump = false;
            this.rigidBody.velocity = Vector3.zero;
            this.rigidBody.AddForce(100f * Vector3.up, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            this.rigidBody.AddForce(new Vector2(-50, 20), ForceMode.Impulse);
            this.rigidBody.detectCollisions = false;
            this.audioSource.PlayOneShot(this.sfxDeath);
            GameManager.gameManager.PlayerCollided();
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Point" && collider.gameObject.GetComponent<MeshRenderer>().isVisible)
        {
            GameManager.gameManager.AddPoint();
            collider.gameObject.GetComponent<Coin>().PlaySound(this.audioSource);
            collider.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
