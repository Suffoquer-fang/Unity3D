using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomMove : MonoBehaviour {

    // Use this for initialization

    private Rigidbody2D rb;

    public float moveSpeed = 10f;

    private Vector3 moveDir;

    private GameObject target;

	void Start () {
        target = GameObject.FindWithTag("Player");

        rb = GetComponent<Rigidbody2D>();

        moveDir = target.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float theta = Random.Range(-20, 20);

        moveDir = Quaternion.AngleAxis(theta, new Vector3(0, 0, 1)) * moveDir;

        rb.velocity = moveDir.normalized * moveSpeed;
	}
}
