using UnityEngine;
using System.Collections;

public class MovableObject : MonoBehaviour {

    public int speed = 1;
    [SerializeField] float resetXPosition;
    [SerializeField] float restartXPosition;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //if (transform.localPosition.x == 
        transform.Translate(Vector3.left * Time.deltaTime * this.speed);

        if (transform.localPosition.x <= resetXPosition)
            transform.position = new Vector3(restartXPosition, transform.localPosition.y, transform.localPosition.z);
	}
}
