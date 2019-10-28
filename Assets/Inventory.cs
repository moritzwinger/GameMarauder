using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;// = new GameObject();
    public Image InventoryImage;
    public string property;

    // pick up item
    public void AddItem(GameObject item)
    {
        // pick up
        if (inventory == null)
        {
            //update UI (Inventory)     
            inventory = item;
            InventoryImage.sprite = item.GetComponent<SpriteRenderer>().sprite;
            item.SendMessage("DoInteraction");
        } 
        // inventory  full
        else
        {
            // drop current item and replace
            DropItem();
            // UpdateInventory
            inventory = item;
            InventoryImage.sprite = item.GetComponent<SpriteRenderer>().sprite;
          
            item.SendMessage("DoInteraction");
        }
    }
    // drop item: for now, the item will respawn in its original place
    public void DropItem()
    {
        inventory.SetActive(true);
        inventory = null;
        InventoryImage.sprite = null;
    }

    // this returns the name of the current item in the inventory
    public string GetInventoryItemName()
    {
        return inventory.name;
    }


    // this method sets the inventory variable (use it to define properties of a given object in the inventory)
    // and replaces the sprite
    public void SetInventoryProperty(string prop, string title)
    {
        this.property = prop;
        this.inventory.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Items/" + title);
        InventoryImage.sprite = this.inventory.GetComponent<SpriteRenderer>().sprite;
    }

    public string GetInventoryProperty()
    {
        return this.property;
    }

}
