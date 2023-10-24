using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private InventoryPageUI InventoryPageUI;
    [SerializeField] private Canvas InventoryCanvas;
    [SerializeField] public int size = 10;
    [HideInInspector] public List<InventoryItemUI> inventoryItems = new List<InventoryItemUI>();

    private void Start() {
        InventoryPageUI.Initalize();
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
}
