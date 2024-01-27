using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ragdoldeath : MonoBehaviour
{

    Rigidbody2D rb;
    Animator animator;
    public GameObject[] bodyParts;
    private S_BaseItem item;
    public int fallingTimerInSeconds;
    Vector2 directionForce;
    bool alreadyFallen = false;


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
            Debug.Log("Collision with Item : " + item.name);
            DeathOfRagdoll();
            GetComponent<S_NPC>().enabled = false;
            Invoke(nameof(OneSecondTimer), 1.0f);
        }

        if (collision.gameObject.tag == "npc")
        {
            StartCoroutine(QuickFloorDisabling());
        }
    }

    private void OneSecondTimer()
    {

        // Do something after 1 second
        Debug.Log("1-second timer reached!");
        for (int i = 0; i < bodyParts.Length; i++)
        {
            bodyParts[i].GetComponent<Rigidbody2D>().isKinematic = false;
            bodyParts[i].GetComponent<Collider2D>().enabled = false;
        }
        StartCoroutine(QuickFloorDisabling());
    }

    private IEnumerator QuickFloorDisabling()
    {
        // Wait for 1 second
        yield return new WaitForSeconds(0.4f);

        // Do something after 0.2 second
        Debug.Log("0.4-second timer reached!");
        for (int i = 0; i < bodyParts.Length; i++)
        {
            bodyParts[i].GetComponent<Rigidbody2D>().isKinematic = false;
            bodyParts[i].GetComponent<Collider2D>().enabled = true;
        }
    }
}
