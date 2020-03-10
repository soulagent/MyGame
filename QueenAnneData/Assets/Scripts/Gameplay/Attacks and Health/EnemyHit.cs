using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour {

    PlayerHealth playerHealth;

    public int enemyDamage = 30;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            print("I kena hit");
            other.gameObject.GetComponent<PlayerHealth>().ChangeHealth(enemyDamage);
        }
    }
}
