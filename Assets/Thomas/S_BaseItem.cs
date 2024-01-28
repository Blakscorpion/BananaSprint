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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "deathzone")
            Destroy(gameObject);
    }


    public virtual Vector3 GetDirection(float speed, Vector3 position)
    {
        return Vector3.zero;
    }
}
