using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Popup : MonoBehaviour
{
    [SerializeField] GameObject containerObject;
    [SerializeField] Player_Interact playerInteract;

    private void Update() 
    {
        if(playerInteract.GetInteractableObject1() != null || playerInteract.GetInteractableObject2() != null)
        {
            Show();
        }
        else{
            Hide();
        }
    }
    
    void Show()
    {
        containerObject.SetActive(true);
    }
    void Hide()
    {
        containerObject.SetActive(false);
    }
}
