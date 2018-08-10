using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DestroyByHit : MonoBehaviour {

    // Use this for initialization
    public int bulletDamage = 30;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "BackGround")
        {
            Destroy(gameObject);
        }
        else if (other.tag == "Enemy")
        {
            Destroy(gameObject);

            other.GetComponent<EnemyHealth>().takeDamage(bulletDamage);
            //Destroy(other.gameObject);
            //TODO
        }
    }
}
