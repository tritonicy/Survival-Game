using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class InventorySO : ScriptableObject
{
    public int size;
    public List<InventoryItem> InventoryItems;
    public void Initalize() {
        InventoryItems = new List<InventoryItem>();
        for(int i = 0; i<size;i++) {
            InventoryItems.Add(InventoryItem.CreateEmptyItem());
        }
    }

    public void AddItem(InventoryItem item) {
        for(int i = 0; i< size ; i++) {
            if(InventoryItems[i].isEmpty) {
                InventoryItems[i] = new InventoryItem(item.item,item.quantity,false);
                return;
            }
        }
    }
    public void DecreaseQuantityItem(int index) {
        Debug.Log(InventoryItems[index].quantity.ToString());
        InventoryItems[index] = InventoryItems[index].DecreaseQuantity();
        Debug.Log(InventoryItems[index].quantity.ToString());
    }

    public void SwapItems(int index1, int index2) {
        InventoryItem decoyItem = InventoryItems[index1];
        InventoryItems[index1] = InventoryItems[index2];
        InventoryItems[index2] = decoyItem;
    }
    public void SetSelectedItem(int index) {
        InventoryItems[index] = InventoryItems[index].SetSelection();
    }
    public void ResetSelectionItem() {
        for(int i = 0; i<size;i++) {
            if(!InventoryItems[i].isEmpty) {
                InventoryItems[i] = InventoryItems[i].ResetSelection();
            }
        }
    }


}
[Serializable]
public struct InventoryItem 
{
    public ItemSO item;
    public int quantity;
    public bool isEmpty;
    public bool isSelected;

    public static InventoryItem CreateEmptyItem() {
        return new InventoryItem{
            item = null,
            quantity = 0,
            isEmpty = true,
        };
    }
    public InventoryItem (ItemSO item, int quantity, bool isSelected) {
        this.item = item;
        this.quantity = quantity;

        this.isEmpty = false;
        this.isSelected = isSelected;
    }
    
    public InventoryItem ResetSelection() {
        return new InventoryItem(this.item,this.quantity,false);
    }
    public InventoryItem SetSelection() {
        return new InventoryItem(this.item,this.quantity,true);
    }
    public InventoryItem DecreaseQuantity() {
        return new InventoryItem(this.item,this.quantity-1,this.isSelected);
    }
}

