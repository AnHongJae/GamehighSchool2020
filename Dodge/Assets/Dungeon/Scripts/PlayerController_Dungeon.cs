﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Dungeon : MonoBehaviour
{

    public Rigidbody D_Rigidbody;
    public float m_Speed = 10f;
    // Update is called once per frame
    void Update()
    {
        //주석 : 설명 필요없는 스크립트를 임시적으로 비활성화하기 위해서 사용
        /* 주석 */
        Rigidbody rigidbody = /*gameObject.*/GetComponent<Rigidbody>();

        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector3 velocity = (new Vector3(xAxis, 0, yAxis).normalized * m_Speed);

        //리지드 바디를 이용한 이동 처리
        velocity.y = D_Rigidbody.velocity.y;
        D_Rigidbody.velocity = velocity;

        //transform을 이용한 이동처리 
        //Vector3 movement = velocity * Time.deltaTime;
        //transform.position = transform.position + movement;

        //transform.position; //월드 위치 좌표
        //transform.rotation;//월드 회전값
        //transform.rotation;//월드 회전값
        //transform.rotation;//월드 회전값
        //transform.rotation;//월드 회전값







        //정답
        //float fireAxis = Input.GetAxis("Fire1");

        //if (fireAxis > 0.95f)
        //    Die();
    }

    public void Die()
    {
        Debug.Log("사망");
        GameManager_Dungeon gameManager = FindObjectOfType<GameManager_Dungeon>();
        gameManager.ReturnToStartPoint();
    }
}
