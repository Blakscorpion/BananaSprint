using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ragdoldeath : MonoBehaviour
{

    Rigidbody2D rb;
    Animator animator;
    public GameObject[] bodyParts;
    public Sprite happyFace;
    public GameObject headTransform;

    public GameObject FXSmoke;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        FXSmoke.gameObject.SetActive(false);

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

        SwitchHead();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "firehydrant")
        //{
        //    DeathOfRagdoll();
        //    if (GetComponent<S_NPC>())
        //    {
        //        GetComponent<S_NPC>().isWalking = false;
        //    }
        //}
        //
        //if (collision.gameObject.tag == "washer")
        //{
        //    DeathOfRagdoll();
        //    if (GetComponent<S_NPC>())
        //    {
        //        GetComponent<S_NPC>().isWalking = false;
        //    }
        //    Invoke(nameof(OneSecondTimer), 1.0f);
        //}
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "item" || collision.gameObject.tag == "head")
        {
            DeathOfRagdoll();
            if (GetComponent<S_NPC>()) { 
            GetComponent<S_NPC>().isWalking = false;
            }
            Invoke(nameof(OneSecondTimer), 1.0f);
            ScoringManager.instance.AddScore();
            StartCoroutine(FX());

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
            ScoringManager.instance.AddScore();

            StartCoroutine(FX());
        }
    }

    IEnumerator FX()
    {
        if (FXSmoke)
        {
            FXSmoke.gameObject.SetActive(true);
            FXSmoke.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            FXSmoke.transform.DOScale(0.1f, 0.2f);

            yield return new WaitForSeconds(0.2f);
            FXSmoke.gameObject.SetActive(false);
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

    private void SwitchHead()
    {
        if (headTransform != null)
        {
            headTransform.GetComponent<SpriteRenderer>().sprite = happyFace;
        }
    }
}
