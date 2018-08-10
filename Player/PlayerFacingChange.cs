using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFacingChange : MonoBehaviour {

    // Use this for initialization

    private SpriteRenderer sr;
    public Sprite left;
    public Sprite right;

	void Start () {
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mousePositionOnScreen = Input.mousePosition;

        Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);

        if (mousePositionInWorld.x < transform.position.x)
        {
            sr.sprite = left;
        }
        else
        {
            sr.sprite = right;
        }
    }
}
