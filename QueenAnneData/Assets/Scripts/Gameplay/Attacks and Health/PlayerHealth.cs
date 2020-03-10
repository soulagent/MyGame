using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public GameObject player;
    public Transform healthBar;
    public Slider healthFill;
    public Text healthText;

    public float currentHealth;
    public float maxHealth;

	// Use this for initialization
	void Start () {
        healthFill.value = currentHealth / maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        //healthBar.LookAt(Camera.main.transform);

        KnightFall();
        healthText.text = Mathf.Round(currentHealth).ToString();
        healthFill.value = currentHealth / maxHealth;

        if (currentHealth < maxHealth) {
            currentHealth += 0.05f;
        }
	}

    public void ChangeHealth(int amount) {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        healthFill.value = currentHealth / maxHealth;
    }

    public void KnightFall() {
        if(currentHealth ==0) {
            print("Died");
        }
    }
}
