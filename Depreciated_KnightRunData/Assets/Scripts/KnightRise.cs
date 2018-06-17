using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightRise : MonoBehaviour {
    /*
    [System.Serializable]
    public struct ToSpawn {
        public Spawn[] spawn;
    }
    
    [System.Serializable]
    public struct Spawn {
        public KnightRise[] GameObject;
    }

    [Header("To Spawn")]
    public float SpawnTimer;
    public KnightRise[] ToRise = new KnightRise[0];
    */

    [Header("To Spawn")]
    public float SpawnTimer;
    public GameObject toSpawn;

    void Update () {
        StartCoroutine(InitiateKnightRise());
    }

    IEnumerator InitiateKnightRise() {
        yield return new WaitForSeconds(SpawnTimer);
        toSpawn.SetActive(true);
        Destroy(this);
    }
}
