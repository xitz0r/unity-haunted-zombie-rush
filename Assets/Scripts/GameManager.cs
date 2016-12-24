﻿using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager = null;

    private bool isPlayerActive = false;
    private bool isGameOver = false;
    private bool isGamePlaying = false;
    private AsyncOperation async;

    [SerializeField]
    private GameObject mainMenu;

    public bool IsPlayerActive { get { return isPlayerActive; } }
    public bool IsGameOver { get { return isGameOver; } }
    public bool IsGamePlaying { get { return isGamePlaying; } }

    void Awake()
    {
        //if (gameManager == null)
            gameManager = this;
        /*else if (gameManager != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        */

        Assert.IsNotNull(this.gameObject);
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
        StartCoroutine("loadGameOver");
    }

    public void PlayerStartedGame()
    {
        this.isPlayerActive = true;
    }

    public void StartGame()
    {
        this.mainMenu.SetActive(false);
        this.isGamePlaying = true;
    }

    IEnumerator loadGameOver()
    {
        Debug.LogWarning("ASYNC LOAD STARTED - " +
           "DO NOT EXIT PLAY MODE UNTIL SCENE LOADS... UNITY WILL CRASH");
        async = SceneManager.LoadSceneAsync("gameover");
        async.allowSceneActivation = false;

        yield return new WaitForSeconds(3);

        async.allowSceneActivation = true;

        SceneManager.UnloadScene("game");

        yield return async;
    }
}
