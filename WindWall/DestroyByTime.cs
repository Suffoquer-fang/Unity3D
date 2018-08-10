using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {

    // Use this for initialization
    public float lifeSpan;
	void Start () {
        Destroy(gameObject, lifeSpan);
	}
	
	// Update is called once per frame
	
}
