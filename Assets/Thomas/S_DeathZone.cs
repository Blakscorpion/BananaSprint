using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        print("rertere");
    }

    private void OnTriggerEnter(Collider other)
    {
        print("fezezf");
    }
}
