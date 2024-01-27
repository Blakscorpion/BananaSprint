using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_NPC : MonoBehaviour
{
    public bool goRight = true;
    public float speed = 2;

    public float miniumTimeForNextMove = 0.5f, maximumTimeForNextMove = 1f;

    Rigidbody2D _rb;
    bool _walk = true;

    private void Start()
    {
        StartCoroutine(WalkBehavior());
        _rb = transform.GetChild(0).GetComponent<Rigidbody2D>();
    }
    

    void Update()
    {
        if (_walk)
        {
            gameObject.transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
            speed *= -1;

        if(collision.gameObject.tag == "item")
        {
            StartCoroutine(DelayBeforeForce(collision.gameObject.GetComponent<S_BaseItem>()));
            gameObject.transform.GetChild(0).gameObject.layer = LayerMask.NameToLayer("Ragdoll");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_force">In Newton</param>
    /// <param name="direction">Normalize values before use</param>
    void RigidBodyAddForce(float _force, Vector3 direction)
    {
        _rb.AddForce(_force * direction);
    }

    IEnumerator DelayBeforeForce(S_BaseItem item)
    {
        yield return new WaitForSeconds(0.05f);
        RigidBodyAddForce(10000, item.GetDirection(speed, _rb.gameObject.transform.position));
        print(goRight);
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
