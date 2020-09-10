using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class HPComponent : MonoBehaviour
{
    public UnityEvent m_OntakeDamage;


    public virtual void TakeDamage(int damage)
    {
        m_OntakeDamage.Invoke();
    }


    public void DestroySelf()
    {
        Destroy(gameObject);
    }

}
