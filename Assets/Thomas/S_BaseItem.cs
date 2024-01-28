using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class S_BaseItem : MonoBehaviour
{
    public float force;
    public Vector3 direction;

    public Renderer renderer;
    public Texture interactedImage;
    float _itemDeathFloor = 1000f;


    public abstract void Interact(GameObject entity);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "npc")
        {
            Rigidbody2D collision2D = gameObject.GetComponent<Rigidbody2D>();
            renderer.material.mainTexture = interactedImage;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }


    public virtual Vector3 GetDirection(float speed, Vector3 position)
    {
        return Vector3.zero;
    }
}
