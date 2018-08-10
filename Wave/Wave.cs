using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

    // Use this for initialization

    //private CircleCollider2D circleCollider;

    public float maxRadius;

    private AudioClip audio;

    public float expandSpeed = 100f;
    float x;
    float y;
    float z;
	void Start () {
        x = transform.localScale.x;
        y = transform.localScale.y;
        z = transform.localScale.z;
        //circleCollider = GetComponent<CircleCollider2D>();
        audio = GetComponent<AudioClip>();
        
	}
	
	// Update is called once per frame
	void Update () {
        x += Time.deltaTime * expandSpeed;
        y += Time.deltaTime * expandSpeed;
        transform.localScale = new Vector3(x, y, z);

        if (x >= maxRadius)
        {
            Destroy(gameObject);
        }
	}
}
