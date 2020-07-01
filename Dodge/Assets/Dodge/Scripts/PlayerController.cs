using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float m_speed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody Rigidbody = /*Gameobject*/ GetComponent<Rigidbody>();

        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        float fire = Input.GetAxis("Fire1");

        Rigidbody.AddForce(new Vector3(xAxis, 0, yAxis) * m_speed);


        if (fire >0.5f) Die();

        //if (Input.GetAxis("Horizontal");
        //{
        //    //transform.position += Vector3.left * m_speed * Time.deltaTime;
        //    Rigidbody.AddForce(Vector3.left * m_speed);
        //}
        //else if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    Rigidbody.AddForce(Vector3.right* m_speed);
        //}
        //else if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    Rigidbody.AddForce(Vector3.forward * m_speed);
        //}
        //else if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    Rigidbody.AddForce(Vector3.back * m_speed);
        //}

        //if(Input.GetKeyDown(KeyCode.Space))
            //Die();
    }
     public void Die()
{
    Debug.Log("사망");
    gameObject.SetActive(false);
}


}


