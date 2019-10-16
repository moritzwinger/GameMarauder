using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionItem : MonoBehaviour
{

    public GameObject currentInterItem = null;
    public InteractionItem currentInterItemScript = null;
    public Inventory inventory;

    private void Update()
    {
        
        //pick up item
        if (Input.GetButtonDown("Interact") && currentInterItem != null)
        {
            //check if item can be stored in inventory: check public inventory var from the script
            if (currentInterItemScript.inventory)
            {
                Debug.Log("adding" + currentInterItem.name);
                inventory.AddItem(currentInterItem);
            }
        }
        // drop item
        if (Input.GetButtonDown("Drop"))
        {
                inventory.DropItem();   
        }
        //use item with an interactable item 
        if (Input.GetButtonDown("Use") && currentInterItem != null)
        {
            //case bucket plus lake 
            if (inventory.GetInventoryItemName() == "bucket"  && currentInterItem.name == "lake" )
            {
                inventory.SetInventoryProperty("full", "bucket_full");
               
                //inventory.UpdateInventoryItem();
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("InteractableItem"))
        {
           // get the game object of the current item
            currentInterItem = other.gameObject;
            // and also get its script
            currentInterItemScript = currentInterItem.GetComponent<InteractionItem>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("InteractableItem"))
        {
            if (other.gameObject == currentInterItem)
            {
                currentInterItem = null;
            }
        }
    }
}
