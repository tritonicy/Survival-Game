using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionUI : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI descriptionText,descriptionName;
    [SerializeField] private Image descriptionImage;

    private void Start() {
        
    }
    public void SetDescription(InventoryItemUI item) {
        descriptionText.text = item.descriptionText;
        descriptionName.text = item.descriptionName;
        descriptionImage.sprite = item.itemImage.sprite;
    }

    public void ResetDescription() {
        descriptionText.text = "";
        descriptionName.text = "";
        descriptionImage.sprite = null;
    }

}
