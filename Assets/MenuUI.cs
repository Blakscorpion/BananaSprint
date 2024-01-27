using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    [SerializeField]
    GameObject menuPanelUI;
    bool isMenuVisible = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PressMenuButton();
        }
    }

    public void PressMenuButton()
    {
        if (!isMenuVisible) {
            menuPanelUI.SetActive(true);
            isMenuVisible = true;
        }
        else {
            menuPanelUI.SetActive(false);
            isMenuVisible = false;                }
    }
}
