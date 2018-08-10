using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    // Use this for initialization

    public int maxHealth = 100;

    private int currHealth;

    void Start()
    {
        currHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

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
            EnemyDead();
        }
    }

    void EnemyDead()
    {
        //
        Destroy(gameObject);
    }
}
