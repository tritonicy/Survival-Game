using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InventoryPageUI : MonoBehaviour
{
    [SerializeField] List<ItemSO> ItemSOs;
    [SerializeField] GameObject ItemPrefab;
    [SerializeField] RectTransform contentPanel;
    [SerializeField] InventoryManager InventoryManager;
    [SerializeField] InventoryItemUI InventoryItemUI;
    public Dictionary<int,InventoryItemUI> itemDict = new Dictionary<int, InventoryItemUI>();

    public void Initalize() {
        for(int i = 0; i < InventoryManager.size; i++) {
            if(ItemSOs[i] != null) {
                GameObject item = Instantiate(ItemPrefab,contentPanel);
                InventoryItemUI inventoryItem = item.GetComponent<InventoryItemUI>();
                itemDict[i] = InventoryManager.inventoryItems[i];
                InventoryManager.inventoryItems.Add(inventoryItem);

                inventoryItem.OnItemPointerClick += HandlePointerClick;

                inventoryItem.SetItemImage(ItemSOs[i].sprite);
                inventoryItem.SetQuantity(ItemSOs[i].quantity);

            }
            else{
                GameObject item = Instantiate(ItemPrefab,contentPanel);
                item.GetComponent<InventoryItemUI>().isEmpty = true;
            }
        }
    }

    public void HandlePointerClick(InventoryItemUI item) {
        Debug.Log(item.descriptionName);
    }

}
