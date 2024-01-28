using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Washer : S_BaseItem
{
    bool alreadyTrigger = false;
    public Collider2D triggerBox;

    public override Vector3 GetDirection(float speed, Vector3 position)
    {
        return (this.transform.position - position).normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "npc")
        {

            if (!alreadyTrigger)
            {
                triggerBox.enabled = true;
                Invoke(nameof(Desactivate), 5);
                //Invoke(nameof(Desactivate), delayBeforeDesactivation);
            }

            alreadyTrigger = true;
        }
    }

    private void Desactivate()
    {
        Rigidbody2D collision2D = gameObject.GetComponent<Rigidbody2D>();
        collision2D.AddTorque(Random.Range(350, 600));
        collision2D.AddForce(new Vector2(Random.Range(-100000, 100000), Random.Range(100000, 300000)));

        this.gameObject.GetComponent<Collider2D>().enabled = false;
        Invoke(nameof(WaitSecond), 3.0f);

    }
    void WaitSecond()
    {
        this.gameObject.GetComponent<Collider2D>().enabled = true;
    }


}
