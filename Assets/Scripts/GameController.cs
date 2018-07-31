using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private GameObject[] Enemy = new GameObject[5];
    
    
    // Use this for initialization
    void Start () {
        
        Enemy[0] = Resources.Load("Prefabs/Enemy") as GameObject;
        Enemy[1] = Resources.Load("Prefabs/Enemy2") as GameObject;
        StartCoroutine(CreateEnemy());
        
	}

    private IEnumerator CreateEnemy()
    {
        while (true)
        {
            System.Random ran = new System.Random();
            
            for (int i = 0; i < 2; i++)
            {
                GameObject enemy = Instantiate(Enemy[1]);
                enemy.transform.position = new Vector3((float)(ran.NextDouble() * 20 - 10), (float)(ran.NextDouble() * 8 - 4), 0);
                enemy.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }
            yield return new WaitForSeconds(3.0f);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
