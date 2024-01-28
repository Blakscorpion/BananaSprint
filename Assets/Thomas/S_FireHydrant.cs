using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class S_FireHydrant : S_BaseItem
{
    public List<Texture> textureAnim = new List<Texture>();
    public List<Texture> fx = new List<Texture>();
    public Renderer PlaneFX;

    public Collider2D triggerBox;
    public float delayBeforeDesactivation = 5;
    bool alreadyTrigger = false;
    bool isTrigger = false;

    private void Start()
    {
        PlaneFX.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "npc")
        {

            if (!alreadyTrigger)
            {
                StartCoroutine(animFireHydrant());
                Invoke(nameof(Desactivate), delayBeforeDesactivation);
            }

            alreadyTrigger = true;
        }
    }

    IEnumerator animFireHydrant()
    {
       
        yield return new WaitForSeconds(0.5f);
        renderer.material.mainTexture = textureAnim[0];
        yield return new WaitForSeconds(0.5f);
        renderer.material.mainTexture = textureAnim[1];
        triggerBox.enabled = true;
        isTrigger = true;
        StartCoroutine(FX());
    }

    IEnumerator FX()
    {
        PlaneFX.enabled = true;
        while (isTrigger)
        {
            yield return new WaitForSeconds(0.05f);
            PlaneFX.material.mainTexture = fx[0];
            yield return new WaitForSeconds(0.05f);
            PlaneFX.material.mainTexture = fx[1];
            yield return new WaitForSeconds(0.05f);
            PlaneFX.material.mainTexture = fx[2];
            yield return new WaitForSeconds(0.05f);
            PlaneFX.material.mainTexture = fx[3];
        }
    }


    private void Desactivate()
    {
        isTrigger = false;
        PlaneFX.enabled = false;
        Rigidbody2D collision2D = gameObject.GetComponent<Rigidbody2D>();
        collision2D.AddTorque(Random.Range(350, 600));
        collision2D.AddForce(new UnityEngine.Vector2(Random.Range(-100000, 100000), Random.Range(100000, 300000)));

        this.gameObject.GetComponent<Collider2D>().enabled = false;
        Invoke(nameof(WaitSecond), 3.0f);

    }
    void WaitSecond()
    {
        this.gameObject.GetComponent<Collider2D>().enabled = true;
    }

}
