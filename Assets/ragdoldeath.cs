using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ragdoldeath : MonoBehaviour
{

    Rigidbody2D rb;
    Animator animator;
    public GameObject[] bodyParts;
    private S_BaseItem item;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DeathOfRagdoll();
        }
    }

    void DeathOfRagdoll()
    {
        animator.enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;

        for (int i = 0; i < bodyParts.Length; i++)
        {
            bodyParts[i].GetComponent<Rigidbody2D>().isKinematic = false;
            bodyParts[i].GetComponent<Collider2D>().enabled=true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "item")
        {
            item = collision.gameObject.GetComponent<S_BaseItem>();
            // Do action according to Item properties //
            

            Debug.Log("Collision with Item : " + item.name);
            DeathOfRagdoll();

            // Do action according to S_NPC properties/methods //

            this.gameObject.GetComponent<S_NPC>().enabled = false;
        }
    }
}
