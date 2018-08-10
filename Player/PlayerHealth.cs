using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    // Use this for initialization

    public int maxHealth = 100;

    private int currHealth;

    public GameObject deadBody;

	void Start () {
        currHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void takeDamage(int damage)
    {
        if (currHealth > damage)
        {
            currHealth -= damage;
        }
        else
        {
            currHealth = 0;
            playerDead();
        }

        GameObject.Find("UIManager").GetComponent<UIManager>().updatePlayerHealth(currHealth);
    }

    void playerDead()
    {
        //TODO
        Instantiate(deadBody, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Debug.Log("PlayerDead");
        GameObject.Find("UIManager").GetComponent<UIManager>().playerFail();
    }
}
