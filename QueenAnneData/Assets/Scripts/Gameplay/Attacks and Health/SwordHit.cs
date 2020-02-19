using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHit : MonoBehaviour {

    EnemyHealth enemyHealth;

    public int swordDamage = 40;

    private void Start() {
        //enemyHealth = GameObject.Find("Enemy").GetComponent<EnemyHealth>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Enemy") {
            //enemyHealth.ChangeHealth(swordDamage);
            print("I hit: " + other.name);
            other.gameObject.GetComponent<EnemyHealth>().ChangeHealth(swordDamage);
        }
    }
}
