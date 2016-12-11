using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager = null;

    private bool isPlayerActive = false;
    private bool isGameOver = false;

    public bool IsPlayerActive { get { return isPlayerActive; } }
    public bool IsGameOver { get { return isGameOver; } }

    void Awake()
    {
        if (gameManager == null)
            gameManager = this;
        else if (gameManager != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlayerCollided()
    {
        this.isGameOver = true;
    }

    public void PlayerStartedGame()
    {
        this.isPlayerActive = true;
    }
}
