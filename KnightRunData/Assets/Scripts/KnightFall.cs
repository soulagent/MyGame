using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightFall : MonoBehaviour {

    public float KillTimer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(InitiateKnightFall());
    }

    IEnumerator InitiateKnightFall() {
        yield return new WaitForSeconds(KillTimer);
        DestroyObject(this.gameObject);
    }
}
