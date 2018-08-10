using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    // Use this for initialization
    public float moveSpeed = 10f;

    private Vector3[] allPoints;

    public Transform path;

    private int currPoint = 0;

    private Vector2 originalPos;


    void Start () {

        originalPos = transform.position;

        allPoints = new Vector3[path.childCount];

        for (int i = 0; i < path.childCount; ++i)
        {
            allPoints[i] = path.GetChild(i).transform.position;
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, allPoints[currPoint], Time.deltaTime * moveSpeed);

        if (transform.position == allPoints[currPoint])
        {
            currPoint++;
            if (currPoint >= allPoints.Length)
            {
                currPoint = 0;
            }
        }
	}

    public void reset()
    {
        transform.position = originalPos;
    }
}
