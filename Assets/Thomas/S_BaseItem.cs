using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class S_BaseItem : MonoBehaviour
{
    public float force;
    public Vector3 direction;
    public abstract void Interact(GameObject entity);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "npc")
        {

            this.gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}
