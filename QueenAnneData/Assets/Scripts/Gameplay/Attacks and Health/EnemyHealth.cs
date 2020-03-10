using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public GameObject enemy;
    public Transform healthBar;
    public Slider healthFill;
    public Text healthText;

    public float currentHealth;
    public float maxHealth;

    void Start() {
        healthFill.value = currentHealth / maxHealth;
    }

    // Update is called once per frame
    void Update() {
        healthBar.LookAt(Camera.main.transform);

        KnightFall();
        //KnightRise();
        healthText.text = currentHealth.ToString();
    }

    public void ChangeHealth(int amount) {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        healthFill.value = currentHealth / maxHealth;
    }

    public void KnightFall() {
        if(currentHealth == 0) {
            Destroy(enemy);
        }
    }
    /*
    public  void KnightRise() {
        if(currentHealth == 0) {
            currentHealth = 100;
            healthFill.value = currentHealth / maxHealth;
        }
    }
    */
}
