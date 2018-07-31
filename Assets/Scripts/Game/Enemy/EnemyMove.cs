using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public float speed;
    public Vector3 target;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.Normalize(target - transform.position) * speed * Time.deltaTime);
        if (transform.position.z < -1)
        {
            Destroy(this.gameObject);
        }
	}
}
