using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindWall : MonoBehaviour {

    private Vector2 moveDir = new Vector2(0, 1);

    public float moveSpeed;

    private Rigidbody2D rb;

    public float setTime;

    private float nowTime;

    public float CDTime;

    

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        
        nowTime = 0;
        
	}
	
	// Update is called once per frame
	void Update () {
        nowTime += Time.deltaTime;

        float theta = Mathf.Atan2(moveDir.x, moveDir.y) / Mathf.PI * 180;
        Debug.Log(theta); 
        transform.rotation = Quaternion.Euler(0, 0, -theta);
        rb.velocity = moveDir.normalized * moveSpeed;

        if (nowTime >= setTime)
        {
            rb.velocity = Vector2.zero;
        }
	}

    public void setDir(Vector2 dir)
    {
        moveDir = dir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
        }
    }
}
