using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinAnim : MonoBehaviour
{
    public Transform m_Target;

    public Vector3 m_Offset;

    protected void Update()
    {
        transform.position = m_Target.position + m_Offset;
    }

}
