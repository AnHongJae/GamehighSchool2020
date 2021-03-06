﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    public Transform[] m_SpawnPoints;
    public GameObject m_RedCube;
    public GameObject m_BlueCube;

    public void SpawnStart()
    {
        StartCoroutine(SpawnProcess());
    }

    public IEnumerator SpawnProcess()
    {
        //큐브가 어디에서 생성될지
        for(int i=0;i <m_SpawnPoints.Length; i++)
        {
            int random = Random.Range(0, 4);
            if(random == 0)
            {
                int random2 = Random.Range(0, 2);
                if (random2 == 0)
                {
                    var gobj = GameObject.Instantiate(m_RedCube);
                    gobj.transform.position = m_SpawnPoints[i].position;
                    gobj.transform.eulerAngles = new Vector3(Random.Range(0, 360f),
                        Random.Range(0, 360f), Random.Range(0, 360f));
                }
                else
                {
                    var gobj = GameObject.Instantiate(m_BlueCube);
                    gobj.transform.position = m_SpawnPoints[i].position;
                    gobj.transform.eulerAngles = new Vector3(Random.Range(0, 360f),
                        Random.Range(0, 360f), Random.Range(0, 360f));
                }
            }
            
        }


        //큐브 생생
        float spawnDelay = Random.Range(3f, 5f);
        yield return new WaitForSeconds(spawnDelay);

        //다시 큐브가 생성 (재귀함수)
        StartCoroutine(SpawnProcess());

    }
}
