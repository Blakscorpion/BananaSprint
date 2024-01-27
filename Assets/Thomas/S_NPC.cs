using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_NPC : MonoBehaviour
{
    public bool goRight = true;
    public float speed = 2;

    public float miniumTimeForNextMove = 0.5f, maximumTimeForNextMove = 1f;

    bool walk = true;

    private void Start()
    {
        StartCoroutine(WalkBehavior());
    }
    

    void Update()
    {
        if (walk)
        {
            gameObject.transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
            speed *= -1;
    }

    //The coroutine that make stop or walk the ia, base on random
    IEnumerator WalkBehavior()
    {
        while (true)
        {
            float waitTime = Random.Range(miniumTimeForNextMove, maximumTimeForNextMove);
            yield return new WaitForSeconds(waitTime);

            walk = Random.value > 0.5f;
        }
    }
}
