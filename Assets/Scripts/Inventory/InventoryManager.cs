using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private InventoryPageUI inventoryPageUI;
    [HideInInspector] private DescriptionUI descriptionUI;
    [SerializeField] public InventorySO inventorySO;
    [SerializeField] private Canvas InventoryCanvas;
    public List<InventoryItem> initialItems = new List<InventoryItem>();

    private void Start() {


        descriptionUI = FindObjectOfType<DescriptionUI>();

        inventorySO.Initalize();
        InitalizeInventory();
        inventoryPageUI.Initalize();
        
        inventoryPageUI.OnItemSwap += HandleSwap;
        inventoryPageUI.OnSelected += HandleSeleciton;
        inventoryPageUI.OnResetSelected += HandleResetSelection;

    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.I)) {
            if(InventoryCanvas.enabled == true) {
                InventoryCanvas.enabled = false;
            }
            else
            InventoryCanvas.enabled = true;
        }
    }

    public void HandleSwap(int index1, int index2) {
        inventorySO.SwapItems(index1,index2);
        InformUI();
    }

    public void InitalizeInventory() {
        foreach(InventoryItem item in initialItems) {
            inventorySO.AddItem(item);
        }
    }
    public void InformUI() {
        ResetInfo();
        for(int i = 0; i< inventorySO.size; i++) {
            if(inventorySO.InventoryItems[i].isEmpty == false) {
                inventoryPageUI.inventoryItems[i].SetItem(inventorySO.InventoryItems[i]);
            }
        }
    }
    public void ResetInfo() {
        for(int i = 0; i< inventorySO.size; i++) {
            inventoryPageUI.inventoryItems[i].ResetItem();
        }
    }
    public void HandleSeleciton(int index) {
        inventorySO.SetSelectedItem(index);
    }
    public void HandleResetSelection() {
        inventorySO.ResetSelectionItem();
    }
}
