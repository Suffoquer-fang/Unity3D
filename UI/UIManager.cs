using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour {

    // Use this for initialization

    public Slider playerHealth;
    public Slider playerSkill;

    public Text infoText;

    bool isUpdating = false;


	void Start () {
        playerHealth.value = 100;
        playerSkill.value = 1;
        infoText.text = "";
	}
	
	// Update is called once per frame
	void Update () {

        if (isUpdating)
            updatePlayerSkill();
		
	}

    public void updatePlayerHealth(float health)
    {
        playerHealth.value = health;
    }

    public void updatePlayerSkill()
    {
        isUpdating = true;
        playerSkill.value = (GameObject.FindWithTag("Player").GetComponent<PlayerAttack>().getNextSkill());

        if (playerSkill.value >= 1)
            isUpdating = false;
    }

    public void playerWin()
    {
        infoText.text = "YOU WIN";
    }

    public void playerFail()
    {
        infoText.text = "YOU FAIL";
    }
}
