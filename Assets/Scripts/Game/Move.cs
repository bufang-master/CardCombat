using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public GameObject Trail;
    private Vector3 m_VecMouse = new Vector3(0, 0, 0);
    private GameObject preTrail;
	// Use this for initialization
	void Start () {
        
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            preTrail = Instantiate(Trail);
            preTrail.name = "Trail";
        }
        if (Input.GetMouseButtonUp(0))
        {
            Destroy(preTrail, 5f);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 ptScreen = Camera.main.WorldToScreenPoint(transform.position);
            m_VecMouse.x = Input.mousePosition.x;
            m_VecMouse.y = Input.mousePosition.y;
            m_VecMouse.z = ptScreen.z;
            preTrail.transform.position = Camera.main.ScreenToWorldPoint(m_VecMouse);
        }
    }
}
