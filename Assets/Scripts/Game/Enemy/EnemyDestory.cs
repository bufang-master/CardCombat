using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestory : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (transform.localScale.x > 1.5 || transform.position.z > 50)
        {
            Destroy(gameObject);
        }
	}
}
