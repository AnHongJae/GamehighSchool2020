using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap2 : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision이 어떤 Collision과 충돌이 일어 났을 때");
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collision이 어떤 Collision과 충돌이 일어나고 있을 때");
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("트리거 안에 어떤 Collider나 Trigger가 들어갔을 때 ");
        if (collision.rigidbody != null)
        {
            var player = collision.rigidbody.GetComponent<PlayerController_Dungeon>();
            if (player != null)
                player.Die();
        }
        Debug.Log("Collision이 어떤 Collision과 충돌이 일어 났을 때");
    }

}
