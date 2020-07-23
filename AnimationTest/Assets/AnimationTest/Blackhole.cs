using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackhole : MonoBehaviour
{
    public float Delay = 3f;
    public float CoolTime = 0f;

    private void Update()
    {
        if (CoolTime >= Delay)
            GetComponent<Animator>().SetTrigger("Die");

        CoolTime += Time.deltaTime;
    }

}
