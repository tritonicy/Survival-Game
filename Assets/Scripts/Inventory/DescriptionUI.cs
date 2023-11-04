using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionUI : MonoBehaviour
{
    [SerializeField] public InventorySO inventorySO;
    [SerializeField] public InventoryPageUI inventoryPageUI;
    [SerializeField] public TextMeshProUGUI descriptionText,descriptionName;
    [SerializeField] private Image descriptionImage;
    [SerializeField] private Button eventButton;
    [SerializeField] private Button dropButton;
    public Action<int> OnChangeQuantity;

    private void Start() {
        ResetDescription();
    }
    public void SetDescription(InventoryItemUI item) {
        descriptionText.text = item.descriptionText;
        descriptionName.text = item.descriptionName;
        descriptionImage.enabled = true;
        descriptionImage.sprite = item.itemImage.sprite;

        eventButton.GetComponent<Image>().enabled = true;
        switch (item.itemType) {
            case ItemType.Block:
            eventButton.GetComponentInChildren<TextMeshProUGUI>().text = "Build";
            break;

            case ItemType.Edible:
            break;

            case ItemType.Wearable:
            eventButton.GetComponentInChildren<TextMeshProUGUI>().text = "Wear";
            break;

        }
        dropButton.GetComponent<Image>().enabled = true;
        dropButton.GetComponentInChildren<TextMeshProUGUI>().text = "Drop";
    }

    public void ResetDescription() {
        descriptionText.text = "";
        descriptionName.text = "";
        descriptionImage.enabled = false;

        eventButton.GetComponent<Image>().enabled = false;
        eventButton.GetComponentInChildren<TextMeshProUGUI>().text = "";
        dropButton.GetComponent<Image>().enabled = false;
        dropButton.GetComponentInChildren<TextMeshProUGUI>().text = "";
    }

    public void OnDropButton() {

    }
}

