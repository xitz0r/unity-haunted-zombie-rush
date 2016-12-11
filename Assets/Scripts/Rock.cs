using UnityEngine;
using System.Collections;

public class Rock : MovableObject {

    [SerializeField] Vector3 topPosition;
    [SerializeField] Vector3 bottomPosition;

    // Use this for initialization
    void Start () {
        StartCoroutine(MoveRock(bottomPosition));
	}

    protected override void Update()
    {
        if (GameManager.gameManager.IsPlayerActive)
            base.Update();
    }

    IEnumerator MoveRock(Vector3 target)
    {
        while (Mathf.Abs((target - transform.localPosition).y) > 0.5f)
        {
            Vector3 direction = target.y == topPosition.y ? Vector3.up : Vector3.down;
            transform.localPosition += direction * Time.deltaTime * this.speed;
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        Vector3 newTarget = target.y == topPosition.y ? bottomPosition : topPosition;

        StartCoroutine(MoveRock(newTarget));
    }
}
