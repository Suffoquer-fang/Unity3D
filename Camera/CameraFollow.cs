using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    // Use this for initialization
    public GameObject target;

    Vector3 offset;
	void Start () {
        offset = target.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if(target)
            transform.position = target.transform.position - offset;
	}
}
