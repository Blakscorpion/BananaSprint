using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_InputManager : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();

    public GameObject itemSelected;
    public int remainingClick = 5;
    private void Start()
    {
        itemSelected = items[0];
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0 && remainingClick>0)
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            worldPosition.z = 0;

            Instantiate(itemSelected, worldPosition, Quaternion.identity);
            remainingClick--;
        }
    }

    public void SelectItem(int number)
    {
        itemSelected = items[number];
    }
}
