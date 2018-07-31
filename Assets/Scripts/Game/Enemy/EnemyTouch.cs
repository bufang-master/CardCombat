using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTouch : MonoBehaviour {

    private Vector3 enterVector;
    private Vector3 endVector;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + "_OnTriggerEnter");
        enterVector = other.transform.position;
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.name + "_OnTriggerExit");
        endVector = other.transform.position;
        endVector = new Vector3(endVector.x, endVector.y, -100);
        if (other.name == "Trail")
        {  //GetComponent<EnemyMove2>().CutDown();
            //GetComponent<Rigidbody>().AddForce(endVector - enterVector);
            GetComponent<EnemyMove2>().CutDown(enterVector - endVector);
            Debug.Log(enterVector.ToString() + "|" + endVector.ToString() + "|" + (enterVector - endVector).ToString());
        }
        //other.gameObject.GetComponent<EnemyMove2>().CutDown();
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.name + "_OnTriggerStay");
    }


}
