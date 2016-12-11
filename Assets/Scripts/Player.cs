using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;

public class Player : MonoBehaviour {

    private Animator animator;
    private bool jump;
    private Rigidbody rigidbody;
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
        this.rigidbody = GetComponent<Rigidbody>();
        this.audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!GameManager.gameManager.IsGameOver && Input.GetMouseButtonDown(0))
        {
            GameManager.gameManager.PlayerStartedGame();
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            this.rigidbody.AddForce(new Vector2(-50, 20), ForceMode.Impulse);
            this.rigidbody.detectCollisions = false;
            this.audioSource.PlayOneShot(this.sfxDeath);
            GameManager.gameManager.PlayerCollided();
        }
    }
}
