using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    // Use this for initialization

    Rigidbody2D rb;

    public float moveSpeed = 10f;

    private Vector2 moveDir = new Vector2(1, 0);

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = moveDir.normalized * moveSpeed;
	}

    public void setTarget(Vector2 dir)
    {
        moveDir = dir;
    }
}
