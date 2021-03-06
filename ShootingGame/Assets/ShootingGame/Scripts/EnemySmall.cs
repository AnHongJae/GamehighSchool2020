﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmall : MonoBehaviour
{
    public float m_Speed = 10f;
    public float AttackTime = 0f;

    public GameObject m_Bullet;
    public GameObject m_EnemyBullet;

    public bool isDead = false;
    
    void Update()
    {
        Vector3 movement = transform.up * m_Speed * Time.deltaTime;
        transform.position -= movement;

        AttackTime += Time.deltaTime;
        if(AttackTime > 0.5)
        {
            var gobj = GameObject.Instantiate(m_EnemyBullet);
            gobj.transform.position = transform.position + new Vector3(0,-1, 0);
            gobj.transform.eulerAngles = transform.eulerAngles + new Vector3(0, 0, 180);
            AttackTime = 0;
        }


        

    }

    public Animator m_Animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_Animator.SetBool("Die", true);
        isDead = true;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

}
