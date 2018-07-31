using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMono : MonoBehaviour {

    List<int> t;

    private void Awake()
    {
        //Debug.Log("Awake :" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fffffff"));
        t = new List<int>();
        t.Add(1);
        t.Add(2);
        t.Add(3);
        t.Add(4);
        t.Add(5);
        t.Add(6);
        t.Add(7);
    }

    //   // Use this for initialization
    //   void Start () {
    //       Debug.Log("Start :" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fffffff"));
    //   }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("碰撞开始");
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("持续碰撞");
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("碰撞结束");
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("触发开始");
    }
    private void OnTriggerStay(Collider other)
    {   
        Debug.Log("持续触发");
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("碰撞结束");
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Update+" + Time.deltaTime);
        TestFor();
        TestForeach();
        TestWhile();
    }

    void TestFor()
    {
        for(int i = 0;i < t.Count; i++)
        {
            Debug.Log(t[i]);
        }
    }
    void TestWhile()
    {
        while (t.GetEnumerator().MoveNext())
        {
            Debug.Log(t.GetEnumerator().Current);
        }
    }
    void TestForeach()
    {
        foreach(var i in t)
        {
            Debug.Log(i);
        }
    }
    //   private void FixedUpdate()
    //   {
    //       Debug.Log("FixedUpdate :" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fffffff"));
    //   }
    //   private void Reset()
    //   {
    //       Debug.Log("Reset :" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fffffff"));
    //   }
    //   private void OnEnable()
    //   {
    //       Debug.Log("OnEnable :" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fffffff"));
    //   }
    //   private void LateUpdate()
    //   {
    //       Debug.Log("LateUpdate :" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fffffff"));
    //   }
    private void OnGUI()
    {
        //Debug.Log("OnGUI+" + Time.deltaTime);
        //GUI.Label(new Rect(100, 200, 100, 100),"<color=white>hell</color>");
        //GUI.Button(new Rect(100, 100, 100, 100), "按钮");
        //if(GUI.Button(new Rect(100, 300, 100, 100), "按钮"))
        //{
        //    Debug.Log("Button2");
        //}

        //if (GUILayout.Button("按钮"))
        //{
        //    Debug.Log("Button1");
        //}
    }
    //private void OnDisable()
    //{
    //    Debug.Log("OnDisable :" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fffffff"));
    //}
    //private void OnDestroy()
    //{
    //    Debug.Log("OnDestroy :" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fffffff"));
    //}
}
