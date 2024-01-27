using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Banana : S_BaseItem
{
    public override Vector3 GetDirection(float speed, Vector3 position)
    {
        return speed > 0 ? Vector3.right : Vector3.left;
    }

    public override void Interact(GameObject entity)
    {
        
    }
}

