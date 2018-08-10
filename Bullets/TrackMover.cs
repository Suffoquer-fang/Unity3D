using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMover : MonoBehaviour {

    // Use this for initialization

    private Rigidbody2D rb;

    private GameObject target;

    public float moveSpeed = 10f;

	void Start () {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = Vector2.right * moveSpeed;

        
	}
	
	// Update is called once per frame
	void Update () {
        while (target == null)
            findTarget();


        rb.velocity = (target.transform.position - transform.position).normalized * moveSpeed;

        //float theta = Mathf.Atan()

        //
        transform.rotation = Quaternion.Euler(0, 0, 45);
        //rb.MoveRotation(45);


	}

    public void setTarget(GameObject _target)
    {
        target = _target;
    }

    void findTarget()
    {
        target = GameObject.FindWithTag("Enemy");
    }
}
