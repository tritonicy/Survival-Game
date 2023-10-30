using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InventoryPageUI : MonoBehaviour
{
    [SerializeField] InventorySO InventorySO;
    [SerializeField] GameObject ItemPrefab;
    [SerializeField] RectTransform contentPanel;
    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] DescriptionUI descriptionUI;
    [SerializeField] MouseFollower mouseFollower;
    [SerializeField] public List<InventoryItemUI> inventoryItems;
    private InventoryItemUI prevSelectedItem; 
    public Action<int,int> OnItemSwap;

    public void Initalize() {
        inventoryItems = new List<InventoryItemUI>();
        for(int i = 0; i < InventorySO.size; i++) {
            GameObject item = Instantiate(ItemPrefab,contentPanel);
            InventoryItemUI inventoryItem = item.GetComponent<InventoryItemUI>();
            inventoryItems.Add(inventoryItem);

                inventoryItem.OnItemPointerClick += HandlePointerClick;
                inventoryItem.OnItemBeginDrag += HandleBeginDrag;
                inventoryItem.OnItemEndDrag += HandleEndDrag;
                inventoryItem.OnItemDrag += HandleDrag;
                inventoryItem.OnItemDrop += HandleDrop;

            if(InventorySO.InventoryItems[i].isEmpty == false) {
            
                inventoryItem.SetItem(InventorySO.InventoryItems[i]);
            }
            else{
                inventoryItem.ResetItem();
            }
        }
    }

    public void HandlePointerClick(InventoryItemUI item) {
        ResetBorders();
        if(!item.isEmpty) {
            if(prevSelectedItem == item){
                ResetBorders();
                prevSelectedItem = null;
                return;
            }
            descriptionUI.SetDescription(item);
            item.itemBorder.SetActive(true);
            prevSelectedItem = item;
        }
        else{
            descriptionUI.ResetDescription();  
        }
    }

    public void HandleBeginDrag(InventoryItemUI item) {
        prevSelectedItem = item;
        mouseFollower.SetFollow(item);
    }

    public void HandleEndDrag(InventoryItemUI item) {
        Debug.Log(item.descriptionName);
        mouseFollower.EndFollow();
    }

    public void HandleDrag(InventoryItemUI item) {
    }

    public void HandleDrop(InventoryItemUI item) {
        int index1 = inventoryItems.IndexOf(prevSelectedItem);
        int index2 = inventoryItems.IndexOf(item);
        if(index1 == -1 || index2 == -1) {
            return;
        }
        ResetBorders();       
        OnItemSwap?.Invoke(index1,index2);
    }

    public void ResetBorders() {
        foreach (InventoryItemUI item in inventoryItems) {
            item.itemBorder.SetActive(false);
        }
    }
}
