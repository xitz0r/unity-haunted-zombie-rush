using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour {

    AsyncOperation async;

    // Use this for initialization
    void Start () {
        StartCoroutine("load");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartGame()
    {
        async.allowSceneActivation = true;
    }

    IEnumerator load()
    {
        Debug.LogWarning("ASYNC LOAD STARTED - " +
           "DO NOT EXIT PLAY MODE UNTIL SCENE LOADS... UNITY WILL CRASH");
        async = SceneManager.LoadSceneAsync("game");
        async.allowSceneActivation = false;
        yield return async;
    }
}
