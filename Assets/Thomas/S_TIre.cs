using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_TIre : S_BaseItem
{
    private void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 20000000);
        StartCoroutine(ChangeLayer());
    }

    IEnumerator ChangeLayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(4f);
            gameObject.layer = LayerMask.NameToLayer("ignoreFloor");
            yield return new WaitForSeconds(1f);
            gameObject.layer = LayerMask.NameToLayer("Default");

        }
    }
}
