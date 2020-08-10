﻿using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject m_Effect;
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        float speed = 5f;

        Vector3 movement = (transform.forward * yAxis ) * speed * Time.deltaTime;
        transform.position += movement;

        transform.Rotate(0, 100f * xAxis * Time.deltaTime, 0);  

        RaycastHit hit;
        Ray ray = new Ray();
        ray.origin = transform.position;
        ray.direction = transform.forward;
        if(Physics.Raycast(ray, out hit, 10f))
        {
            var gobj = GameObject.Instantiate(m_Effect, hit.point, Quaternion.identity);
            gobj.transform.localScale = 0.05f * Vector3.one;
        }

        //빨간 선 그리기  
        //Debug.DrawLine(Vector3.zero, Vector3.zero + Vector3.forward * 100f, Color.red);
    }
}
