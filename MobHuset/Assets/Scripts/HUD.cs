using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Inventory Inventory;
    public Inventory _Inventory;

   // Use this for initialization
   void Start ()  {
       Inventory.ItemAdded += InventoryScript_ItemAdded;
       Inventory.ItemRemoved += Inventory_ItemRemoved;
   }

   private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
   {
       Transform inventoryPanel = transform.Find("InventoryPanel");
       foreach(Transform slot in inventoryPanel)
        {
            //border image
            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();
            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();

            //we find empty slot
            if(!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;
                itemDragHandler.Item = e.Item;

                break;
            }
        }
   }

    private void Inventory_ItemRemoved(object sender, InventoryEventArgs e) {
        Transform inventoryPanel = transform.Find("InventoryPanel");
        foreach (Transform slot in inventoryPanel) {
            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Image image = imageTransform.GetComponent<Image>();
            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();
            //image.enabled = false;
           
            //we found the item in the UI
            if(itemDragHandler.Item.Equals(e.Item)) {
               image.enabled = false;
               //image.sprite = null;
               //itemDragHandler.Item = null;
               break;
            }
        }
    }
}