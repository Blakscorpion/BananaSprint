using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_NPC : MonoBehaviour
{
    public bool goRight = true;
    public float speed = 2;
    public bool isWalking = true;
    public Animator currentAnimator;

    public float miniumTimeForNextMove = 0.5f, maximumTimeForNextMove = 1f;

    public Rigidbody2D _rb;
    public bool _walk = true;

    private void Start()
    {
        StartCoroutine(WalkBehavior());
        _rb = transform.GetChild(0).GetComponent<Rigidbody2D>();
        currentAnimator= GetComponent<Animator>();
    }
    

    void Update()
    {
        if (gameObject.transform.position.y <= -100)
        {
            Destroy(gameObject);
            S_SpawnerStatic.entityAmount--;
        }
        if (isWalking && _walk)
        {
            gameObject.transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (!_walk) { currentAnimator.SetBool("isWalking", false); }
        else { currentAnimator.SetBool("isWalking", true); }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            speed *= -1;
            gameObject.transform.localScale = new Vector3(Mathf.Clamp(-speed, -1, 1),
                gameObject.transform.localScale.y,
                gameObject.transform.localScale.z);
        }

        if(collision.gameObject.tag == "item")
        {
            StartCoroutine(DelayBeforeForce(collision.gameObject.GetComponent<S_BaseItem>()));
            gameObject.transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("Ragdoll");
        }

        if(collision.gameObject.tag == "chilly")
        {
            Destroy(collision.gameObject);
            gameObject.layer = LayerMask.NameToLayer("Ragdoll");
            gameObject.tag = "head";
            speed *= 3;
            _rb.mass = 6000;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_force">In Newton</param>
    /// <param name="direction">Normalize values before use</param>
    public void RigidBodyAddForce(float _force, Vector3 direction)
    {
        _rb.AddForce(_force * direction);
    }

    IEnumerator DelayBeforeForce(S_BaseItem item)
    {
        yield return new WaitForSeconds(0.05f);
        RigidBodyAddForce(10000, item.GetDirection(speed, _rb.gameObject.transform.position));
    }


        //The coroutine that make stop or walk the ia, base on random
        IEnumerator WalkBehavior()
    {
        while (true)
        {
            float waitTime = Random.Range(miniumTimeForNextMove, maximumTimeForNextMove);
            yield return new WaitForSeconds(waitTime);

            _walk = Random.value > 0.5f;
        }
    }


    //Put on death
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "firehydrant")
        {
            S_BaseItem tmp = collision.gameObject.GetComponentInParent<S_BaseItem>();

            RigidBodyAddForce(tmp.force, tmp.direction);
        }

        //if (collision.gameObject.tag == "washer")
    }


}
