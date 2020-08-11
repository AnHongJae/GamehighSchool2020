using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCube : MonoBehaviour
{
    public GameObject m_RedCube;
    public float m_Speed = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        var movement = Vector3.down * m_Speed * Time.deltaTime;
        transform.position += movement;
    }

    public void OnPointerDownEvent()
    {
        GameManager.Instance.AddScore();
        Destroy(gameObject);
        GameManager.Instance.AddTime();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Plane")
        {
            Destroy(gameObject);
            GameManager.Instance.DamageLife();
        }
    }


}
