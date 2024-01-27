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
            Invoke(nameof(WaitSecond), 3.0f);
        }
    }

    void WaitSecond()
    {
        this.gameObject.GetComponent<Collider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }


    public virtual Vector3 GetDirection(float speed, Vector3 position)
    {
        return Vector3.zero;
    }
}
