using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float m_Speed = 10f;
    public GameObject m_Bullet;
    public float CreatTime = 0f;


    void Update()
    {
        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");

        Vector3 velocity = (new Vector3(xMove,yMove, 0).normalized * m_Speed);

        Vector3 movement = velocity * Time.deltaTime;
        transform.position = transform.position + movement;


        

        CreatTime += Time.deltaTime;
        if(CreatTime>0.5 && Input.GetKey(KeyCode.Space))
        {
            var gabj = GameObject.Instantiate(m_Bullet);
            gabj.transform.position = transform.position + new Vector3(0, 4, 0);

            var gabj2 = GameObject.Instantiate(m_Bullet);
            gabj2.transform.position = transform.position + new Vector3(-1, 4, 0);
            gabj2.transform.eulerAngles = transform.eulerAngles + new Vector3(0,4,25); 

            var gabj3 = GameObject.Instantiate(m_Bullet);
            gabj3.transform.position = transform.position + new Vector3(1, 4, 0);
            gabj3.transform.eulerAngles = transform.eulerAngles + new Vector3(1, 4, -25);

            CreatTime = 0;

        }
    }






}
