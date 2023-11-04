using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] InventorySO inventorySO;
    [SerializeField] InventoryManager inventoryManager;
    public void OnDropButtonClicked() {
        foreach (InventoryItem item in inventorySO.InventoryItems) {
            if(item.isSelected) {
                inventorySO.DecreaseQuantityItem(inventorySO.InventoryItems.IndexOf(item));
                inventoryManager.InformUI();
                return;
            }
        }
    }
}
