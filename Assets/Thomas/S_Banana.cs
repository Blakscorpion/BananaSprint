using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Banana : S_BaseItem
{
    public override Vector3 GetDirection(float speed, Vector3 position)
    {
        return speed > 0 ? Vector3.right : Vector3.left;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "npc")
        {
            renderer.material.mainTexture = interactedImage;
            Rigidbody2D collision2D = gameObject.GetComponent<Rigidbody2D>();
            collision2D.AddTorque(Random.Range(350, 600));
            collision2D.AddForce(new Vector2(Random.Range(-100000, 100000), Random.Range(100000, 300000)));

            this.gameObject.GetComponent<Collider2D>().enabled = false;
            Invoke(nameof(WaitSecond), 3.0f);

        }
    }

    void WaitSecond()
    {
        this.gameObject.GetComponent<Collider2D>().enabled = true;
    }
}

