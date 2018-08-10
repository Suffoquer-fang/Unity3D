using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour {

	// Use this for initialization
    public int bulletDamage = 10;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
            collision.GetComponent<PlayerHealth>().takeDamage(bulletDamage);
        }
    }
}
