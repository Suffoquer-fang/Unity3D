using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotate : MonoBehaviour {

    // Use this for initialization

    public GameObject shotSpawnRight;
    public GameObject shotSpawnLeft;

    private SpriteRenderer sr;

    public Sprite left;
    public Sprite right;

	void Start () {
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void rotate(Vector2 moveDir)
    {
        float theta = Mathf.Atan2(moveDir.x, moveDir.y) / Mathf.PI * 180;
        //transform.rotation = Quaternion.Euler(0, 0, -90 - theta);
        
        if (moveDir.x > 0)
        {
            sr.sprite = right;
            transform.rotation = Quaternion.Euler(0, 0, 90 - theta);
        }
        else
        {
            sr.sprite = left;
            transform.rotation = Quaternion.Euler(0, 0, -90 - theta);
            
        }

        //Debug.Log(theta);

    }

    public GameObject getShotSpawn()
    {
        if (sr.sprite == left)
        {
            return shotSpawnLeft;
        }
        else
        {
            return shotSpawnRight;
        }
    }
}
