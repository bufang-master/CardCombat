using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public Vector3 pos;

    struct TestStruct
    {
        private int id;
        private string name;

        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

    }

    class baseClass
    {
        public virtual void method1()
        {
            Debug.Log("1");
        }
        public virtual void method2()
        {
            Debug.Log("2");
        }
    }

    class extrenClass : baseClass
    {
        //public sealed override void method1()
        //{
        //    Debug.Log("11");
        //}
        //public override void method2()
        //{
        //    Debug.Log("12");
        //}
    }

    class thridClass : extrenClass
    {
        public override void method2()
        {
            Debug.Log("22");
        }
    }

    List<TestStruct> t = new List<TestStruct>();

	// Use this for initialization
	void Start () {
        
    }

    private void Change(ref int n, out int m,params int[] temp)
    {
        n = 100;
        //Debug.Log(m);
        m = 10;
        foreach(var i in temp)
        {
            Debug.Log(i);
        }
    }



    // Update is called once per frame
    void Update () {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(pos), Time.deltaTime);
	}
}
