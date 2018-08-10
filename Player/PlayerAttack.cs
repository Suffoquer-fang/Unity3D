using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    // Use this for initialization

    public GameObject bullet;

    public GameObject trackBullet;

    private GameObject target;

    public GameObject wave;

    public GameObject gun;

    private GameObject shotSpawn;

    float leftnextFire = 0;
    float rightnextFire = 0;

    float nextSkill = 0;

    public float fireRate = 0.1f;
    

    private float cdTime;



	void Start () {
        cdTime = wave.GetComponent<WindWall>().CDTime;
        nextSkill = cdTime;

	}
	
	// Update is called once per frame
	void Update () {
        

        Vector2 moveDir = new Vector2(1, 0);

        Vector3 mousePositionOnScreen = Input.mousePosition;
        
        Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);

        moveDir = mousePositionInWorld - transform.position;

        gun.GetComponent<WeaponRotate>().rotate(moveDir);


        shotSpawn = gun.GetComponent<WeaponRotate>().getShotSpawn();

        leftnextFire += Time.deltaTime;
        rightnextFire += Time.deltaTime;
        nextSkill += Time.deltaTime;

        float theta = Mathf.Atan2(moveDir.x, moveDir.y) / Mathf.PI * 180;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Attack");

            
            //GameObject newBullet = Instantiate(trackBullet, transform.position, Quaternion.identity);
            
            //newBullet.GetComponent<TrackMover>().setTarget(target);

        }

        
        if(Input.GetMouseButton(0) && leftnextFire > fireRate)
        {
            leftnextFire = 0;


            
            GameObject newBullet = Instantiate(bullet, shotSpawn.transform.position, Quaternion.Euler(new Vector3(0, 0, -theta)));
            newBullet.GetComponent<Mover>().setTarget(moveDir);
        }

        if (Input.GetKeyDown(KeyCode.E) && nextSkill >= cdTime)
        {
            nextSkill = 0;
            

            moveDir = mousePositionInWorld - transform.position;

            Instantiate(wave, transform.position, Quaternion.identity).GetComponent<WindWall>().setDir(moveDir);

            GameObject.Find("UIManager").GetComponent<UIManager>().updatePlayerSkill();
        }

        if (Input.GetMouseButton(1) && rightnextFire > 3 * fireRate)
        {
            rightnextFire = 0;
            shotGunAttack();
        }

    }

    public float getNextSkill()
    {
        return nextSkill / cdTime;
    }

    void shotGunAttack()
    {
        Vector2 moveDir;
        Vector3 mousePositionOnScreen = Input.mousePosition;
        //mousePositionOnScreen.z = screenPosition.z;
        Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);

        moveDir = mousePositionInWorld - transform.position;


        float theta = Mathf.Atan2(moveDir.x, moveDir.y) / Mathf.PI * 180;

        Vector2 rightDir = Quaternion.AngleAxis(15, new Vector3(0, 0, 1)) * moveDir;
        Vector2 leftDir = Quaternion.AngleAxis(-15, new Vector3(0, 0, 1)) * moveDir;

        GameObject leftBullet = Instantiate(bullet, shotSpawn.transform.position, Quaternion.Euler(new Vector3(0, 0, -theta - 15)));
        leftBullet.GetComponent<Mover>().setTarget(leftDir);

        GameObject midBullet = Instantiate(bullet, shotSpawn.transform.position, Quaternion.Euler(new Vector3(0, 0, -theta)));
        midBullet.GetComponent<Mover>().setTarget(moveDir);

        GameObject rightBullet = Instantiate(bullet, shotSpawn.transform.position, Quaternion.Euler(new Vector3(0, 0, -theta + 15)));
        rightBullet.GetComponent<Mover>().setTarget(rightDir);
    }
}
