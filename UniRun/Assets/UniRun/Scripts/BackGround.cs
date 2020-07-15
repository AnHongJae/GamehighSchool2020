using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{

    private float width;

    private void Awake()
    {
        var collider = GetComponent<BoxCollider2D>();
        width = collider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        var collider = GetComponent<BoxCollider2D>();
        float width = collider.size.x;

        if(transform.position.x < -width)
        {
            transform.position += Vector3.right * 2f * width;
        }
    }
}
