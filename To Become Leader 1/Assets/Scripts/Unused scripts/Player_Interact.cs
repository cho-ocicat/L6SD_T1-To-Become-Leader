using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interact : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if(collider.TryGetComponent(out NPC_Interactable npcInteract))
                {
                    npcInteract.Interact();
                }
                if(collider.TryGetComponent(out Lux_Interact LuxInteract))
                {
                    LuxInteract.LuxInteract();
                }
            }
        }
    }

    public NPC_Interactable GetInteractableObject2()
    {
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if(collider.TryGetComponent(out NPC_Interactable npcInteract))
            {
                return npcInteract;
            }
        }
        return null;
    }

    public Lux_Interact GetInteractableObject1()
    {
        float interactRange = 3f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if(collider.TryGetComponent(out Lux_Interact LuxInteract))
            {
                return LuxInteract;
            }
        }
        return null;
    }
    
}
