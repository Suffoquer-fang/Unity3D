using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    // Use this for initialization

    public enum attackMode
    {
        normalShot,
        gunShot,
        roundShot,
    };

    public GameObject enemyBullet;
    public float fireRate = 0.2f;

    public float attackRate = 2;

    public int firePerAttack = 3;

    private float nextFire;

    private float nextAttack;

    private GameObject player;

    public attackMode mode;

	void Start () {
        nextFire = 0;
        nextAttack = 0;
        player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        nextAttack += Time.deltaTime;

        

        if (nextAttack >= attackRate)
        {
            nextAttack = 0;
            StartCoroutine(Attack());
        }
	}

    IEnumerator Attack()
    {
        for (int i = 0; i < firePerAttack; ++i)
        {
            Fire(mode);
            yield return new WaitForSeconds(fireRate);
        }
    }

    void Fire(attackMode mode)
    {
        if (mode.ToString() == "normalShot")
            normalShot();
        else if (mode.ToString() == "gunShot")
            gunShot();
        else if (mode.ToString() == "roundShot")
            roundShot();

    }

    void createShot(Vector2 dir)
    {
        GameObject newBullet = Instantiate(enemyBullet, transform.position, Quaternion.identity);
        newBullet.GetComponent<Mover>().setTarget(dir);
    }

    void normalShot()
    {
        if (player == null) return;
        Vector2 moveDir = player.transform.position - transform.position;
        createShot(moveDir);
    }

    void gunShot()
    {
        if (player == null) return;
        Vector2 moveDir = player.transform.position - transform.position;
        Vector2 rightDir = Quaternion.AngleAxis(15, new Vector3(0, 0, 1)) * moveDir;
        Vector2 leftDir = Quaternion.AngleAxis(-15, new Vector3(0, 0, 1)) * moveDir;

        GameObject leftBullet = Instantiate(enemyBullet, transform.position, Quaternion.identity);
        leftBullet.GetComponent<Mover>().setTarget(leftDir);

        GameObject midBullet = Instantiate(enemyBullet, transform.position, Quaternion.identity);
        midBullet.GetComponent<Mover>().setTarget(moveDir);

        GameObject rightBullet = Instantiate(enemyBullet, transform.position, Quaternion.identity);
        rightBullet.GetComponent<Mover>().setTarget(rightDir);
    }

    void roundShot()
    {
        if (player == null) return;
        Vector2 moveDir = new Vector2(0, 1);

        for (int i = 0; i < 12; ++i)
        {
            createShot(moveDir);
            moveDir = Quaternion.AngleAxis(30, new Vector3(0, 0, 1)) * moveDir;
        }
    }
}
