using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ragdoldeath : MonoBehaviour
{

    Rigidbody2D rb;
    Animator animator;
    public GameObject[] bodyParts;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    void DeathOfRagdoll()
    {
        if (animator != null)
        {
            animator.enabled = false;
        }
        gameObject.GetComponent<Collider2D>().enabled = false;

        for (int i = 0; i < bodyParts.Length; i++)
        {
            bodyParts[i].GetComponent<Rigidbody2D>().isKinematic = false;
            bodyParts[i].GetComponent<BoxCollider2D>().enabled=true;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "item" || collision.gameObject.tag == "head")
        {
            DeathOfRagdoll();
            if (GetComponent<S_NPC>()) { 
            GetComponent<S_NPC>().enabled = false;
            }
            Invoke(nameof(OneSecondTimer), 1.0f);
        }

        if (collision.gameObject.tag == "npc")
        {
            //Disabling colider to let the ragdol fall
            for (int i = 0; i < bodyParts.Length; i++)
            {  
                bodyParts[i].GetComponent<BoxCollider2D>().enabled = false;
            }
            //Quickly re-enabling thecolliders to let the ragdoll stands on the next floor
            Invoke(nameof(QuickFloorEnabling), 0.4f);
        }
    }

    private void OneSecondTimer()
    {
        for (int i = 0; i < bodyParts.Length; i++)
        {
            bodyParts[i].GetComponent<BoxCollider2D>().enabled = false;
        }
        Invoke(nameof(QuickFloorEnabling), 0.6f);
    }

    private void QuickFloorEnabling()
    { 
        for (int i = 0; i < bodyParts.Length; i++)
        {
            bodyParts[i].GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
