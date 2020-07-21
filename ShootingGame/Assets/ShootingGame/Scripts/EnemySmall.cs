using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmall : MonoBehaviour
{
    public float m_Speed = 5f;
    
    void Update()
    {
        Vector3 movement = transform.up * m_Speed * Time.deltaTime;
        transform.position -= movement;
    }
}
