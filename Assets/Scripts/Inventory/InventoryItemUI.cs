using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItemUI : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler, IPointerClickHandler
{
    [Header("Description")]
    [HideInInspector] public TextMeshProUGUI descriptionText;
    [HideInInspector] public TextMeshProUGUI descriptionName;
    [HideInInspector] public Image descriptionImage;

    [Header("Item") ]
    [SerializeField] private TextMeshProUGUI quantity;
    [SerializeField] private Image itemImage;
    [SerializeField] private Image itemBorderImage;
    public bool isEmpty = false;

    public Action<InventoryItemUI> OnItemPointerClick, OnItemBeginDrag, OnItemDrag, OnItemEndDrag;

    private void Start() {
    }
    public void SetItemImage(Sprite image) {
        this.itemImage.sprite = image;
    }

    public void SetQuantity(int quantity) {
        this.quantity.text = quantity.ToString();
    }

    public void SetDescription(string description, string name, Image image) {
        descriptionText.text = description;
        descriptionName.text = name;
        descriptionImage = image;
    } 

    public void OnDrag(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left) {
            OnItemPointerClick.Invoke(this);
        }
    }
}
