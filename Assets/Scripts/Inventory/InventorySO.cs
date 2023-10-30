using System;
using System.Collections;
using System.Collections.Generic;
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
                InventoryItems[i] = new InventoryItem(item.item,item.quantity);
                return;
            }
        }
    }

    public void SwapItems(int index1, int index2) {
        InventoryItem decoyItem = InventoryItems[index1];
        InventoryItems[index1] = InventoryItems[index2];
        InventoryItems[index2] = decoyItem;
    }


}
[Serializable]
public struct InventoryItem 
{
    public ItemSO item;
    public int quantity;
    public bool isEmpty;

    public static InventoryItem CreateEmptyItem() {
        return new InventoryItem{
            item = null,
            quantity = 0,
            isEmpty = true
        };
    }
    public InventoryItem (ItemSO item, int quantity) {
        this.item = item;
        this.quantity = quantity;

        isEmpty = false;
        }
    }

