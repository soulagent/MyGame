using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RMScript : MonoBehaviour {

    public int RunSpeed;

    void OnAnimatorMove() {
        Animator animator = GetComponent<Animator>();
        /*
        if (animator) {
            Vector3 newPosition = transform.position;
            newPosition.z += animator.GetFloat("RunSpeed") * Time.deltaTime;
            transform.position = newPosition;
        }
        */
        if (animator) {
            Vector3 newPosition = transform.position;
            newPosition.z += RunSpeed * Time.deltaTime;
            transform.position = newPosition;
        }
    }
}
