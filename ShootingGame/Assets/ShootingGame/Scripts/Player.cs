using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float m_Speed = 10f;

    void Update()
    {
        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");

        Vector3 velocity = (new Vector3(xMove,yMove, 0).normalized * m_Speed);

        Vector3 movement = velocity * Time.deltaTime;
        transform.position = transform.position + movement;

            
    }






}
