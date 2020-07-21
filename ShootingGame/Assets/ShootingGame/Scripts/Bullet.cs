using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float m_Speed = 2f;

    public float DeathTime = 5f;

    private void Update()
    {
        Vector3 movement = transform.up * m_Speed * Time.deltaTime;
        transform.position += movement;

        DeathTime += Time.deltaTime;

        if (DeathTime >= 2)
        {
            Destroy(gameObject);
            DeathTime = 0;
        }

    }
}
