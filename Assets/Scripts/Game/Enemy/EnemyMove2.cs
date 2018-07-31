using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove2 : MonoBehaviour {

    public float speed;
    private float time;
    private float rotations;

    private Vector3 target;
    private bool cutDown;
	// Use this for initialization
	void Start () {
        time = 0;
        rotations = 0;
        cutDown = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (!cutDown)
        {
            time += Time.deltaTime;
            rotations = Time.deltaTime * 100;
            transform.localScale += new Vector3(speed * Mathf.Sqrt(time), speed * Mathf.Sqrt(time), speed * Mathf.Sqrt(time));
            transform.Rotate(new Vector3(rotations, rotations, rotations));
        }
        else
        {
            transform.Translate(Vector3.Normalize(target) * speed * 3000 * Time.deltaTime);
        }
	}

    public void CutDown(Vector3 force)
    {
        if (!cutDown)
        {
            cutDown = true;
            target = force;
        }
    }
}
