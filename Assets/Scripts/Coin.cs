using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

public class Coin : MonoBehaviour {

    [SerializeField]
    public AudioClip audioClip;

    void Awake()
    {
        Assert.IsNotNull(this.audioClip);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlaySound(AudioSource audioSource)
    {
        audioSource.PlayOneShot(this.audioClip);
    }

}
