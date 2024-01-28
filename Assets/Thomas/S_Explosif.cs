using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Explosif : S_BaseItem
{
    Rigidbody2D _rb;

    private void Start()
    {
        Invoke(nameof(Explode), 2.0f);
        Invoke(nameof(SelfDestroy), 2.55f);
    }

    public override Vector3 GetDirection(float speed, Vector3 position)
    {
        return (position - gameObject.transform.position).normalized;
    }


    public void Explode()
    {
        gameObject.transform.DOScale(new Vector3(4, 4, 4), 0.5f);
    }
    
    void SelfDestroy()
    {
        Destroy(gameObject);
    } 
}
