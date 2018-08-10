using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    // Use this for initialization

    Rigidbody2D rb;

    public float moveSpeed = 10f;

    private Animation anim;

    private Animator animator;

    bool isAlive = true;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {

        if (!isAlive) return;
        //anim.Play();
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 dest = transform.position + moveSpeed * Vector3.right;
            rb.MovePosition(dest);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Vector3 dest = transform.position + moveSpeed * Vector3.left;
            rb.MovePosition(dest);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            Vector3 dest = transform.position + moveSpeed * Vector3.up;
            rb.MovePosition(dest);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Vector3 dest = transform.position + moveSpeed * Vector3.down;
            rb.MovePosition(dest);
        }
        else
        {
            //anim.Stop();
        }

        


    }
    public void playerDead()
    {
        isAlive = false;
    }
}
