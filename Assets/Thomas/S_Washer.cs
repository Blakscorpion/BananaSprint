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
                //Invoke(nameof(Desactivate), delayBeforeDesactivation);
            }

            alreadyTrigger = true;
        }
    }

    
}
