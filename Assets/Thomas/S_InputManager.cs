using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_InputManager : MonoBehaviour
{
    public GameObject banana;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            worldPosition.z = 0;

            Instantiate(banana, worldPosition, Quaternion.identity);
        }
    }
}
