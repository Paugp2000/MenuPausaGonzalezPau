using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] GameObject canvasMenu;
    private bool activeMenu = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            ShowMenuPausa();
            
        }
        
    }
    private void ShowMenuPausa()
    {
        if(!activeMenu )
        {
            canvasMenu.SetActive(true);
            Time.timeScale = 0f;
            activeMenu = true;
        }

        else if (activeMenu ) 
        {
            canvasMenu.SetActive(false);
            Time.timeScale = 1f;
            activeMenu = false;
           
        }
       
        
    }
}
