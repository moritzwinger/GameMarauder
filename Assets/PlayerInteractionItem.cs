    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionItem : MonoBehaviour
{
    public GameObject[] allItems = new GameObject[20];
    public GameObject currentInterItem = null;
    public InteractionItem currentInterItemScript = null;
    public Inventory inventory;


    private void Awake()
    {
        // initialize all game objects of items and put them in an array, so they can easily be accessed

        // get all gameobjects
       // Resources.FindObjectsOfTypeAll(typeof(GameObject))
    }


    private void Update()
    {
        //INTERACT
        //pick up item
        if (Input.GetButtonDown("Interact") && currentInterItem != null)
        {
            //check if item can be stored in inventory: check public inventory var from the script
            if (currentInterItemScript.inventory)
            {
                inventory.AddItem(currentInterItem);
            }
            // cant be stored in inventory: do something else
            // read sign
            else if (currentInterItem.name == "Shrooms")
            {
                //allItems[4].SetActive(false);
                for (int i = 5; i<=11; i++)
                {
                    allItems[i].SetActive(true);
                }
                    
            }
        }
        // drop item
        if (Input.GetButtonDown("Drop"))
        {
                inventory.DropItem();   
        }

        // USE
        // item with an interactable environment 
        if (Input.GetButtonDown("Use") && currentInterItem != null)
        {
            // bucket plus lake gives fulll bucket
            if (inventory.GetInventoryItemName() == "bucket" && currentInterItem.name == "lake")
            {
                inventory.SetInventoryProperty("full", "bucket_full");

                //inventory.UpdateInventoryItem();
            }
            // interactable objects that cant be picked up

            // full bucket puls plant grows tree and yields fruit 
            if (inventory.GetInventoryItemName() == "bucket" && currentInterItem.name == "plant" && inventory.GetInventoryProperty() == "full")
            {
                //1. empty bucket
                inventory.SetInventoryProperty("empty", "bucket");
                //2. play growing tree animation once
                currentInterItem.GetComponent<Animator>().Play("PlantAnim");
                //3. make fruit visible: this is horrible make gameobject database TODO
                allItems[0].SetActive(true);
            }
            //fruit + animal = dead animal => can pass
            if (inventory.GetInventoryItemName() == "fruit" && currentInterItem.name == "Animal")
            {
                //turn off colliders
                allItems[3].GetComponent<BoxCollider2D>().enabled = false;
                //kill animal: ie switch sprite to dead
                allItems[3].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Characters/animal_dead");
            }
            //boulder + x = hand becomes purpledrank
            if (inventory.GetInventoryItemName() == "Boulder1" && currentInterItem.name == "TheX")
            {
                Debug.Log("PD");
                //change hand to purple drank
                allItems[5].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Environment/purpledrank");
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

    void enterAcidMode()
    {
       
    }
}
