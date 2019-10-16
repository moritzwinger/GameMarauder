using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionItem : MonoBehaviour
{
    public bool inventory; // item can (true) or cannot (false) be added to inventory

    // noteL this function is called from PlayerInteractionItem: if a player presses 
    // 'Interaction' this will be called
    public void DoInteraction()
    {
        //Pick up and put into inventory:
        // make disappear
        gameObject.SetActive(false);
    }
}
