using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float CreatTime = 0;
    public float Rand;

    public GameObject Enemy;

    void Update()
    {

        Rand = Random.Range(-8, 8);
        CreatTime += Time.deltaTime;

        if(CreatTime > 2)
        {
            var goj = GameObject.Instantiate(Enemy);
            goj.transform.position = new Vector3(Rand * 4, 42);
            //goj.transform.eulerAngles = new Vector3(0, 0, 360);

            CreatTime = 0;
        }


        
    }
}
