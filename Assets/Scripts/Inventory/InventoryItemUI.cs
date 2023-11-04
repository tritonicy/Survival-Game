using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItemUI : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler, IPointerClickHandler, IDropHandler
{
    [Header("Description")]
    [HideInInspector] public string descriptionText;
    [HideInInspector] public string descriptionName;

    [Header("Item") ]
    [SerializeField] public TextMeshProUGUI quantity;
    [SerializeField] public Image itemImage;
    [SerializeField] public GameObject itemBorder;
    [SerializeField] public bool isEmpty;
    [SerializeField] public ItemType itemType;
    public bool isSelected{get;set;}

    public Action<InventoryItemUI> OnItemPointerClick, OnItemBeginDrag, OnItemDrag, OnItemEndDrag, OnItemDrop;

    public void SetItemImage(Sprite sprite) {
        this.itemImage.sprite = sprite;
    }

    public void SetQuantity(int quantity) {
        this.quantity.text = quantity.ToString();
    }

    public void SetItemDescription(string name, string description) {
        descriptionName = name;
        descriptionText = description;

    }
    public void SetItemType(ItemType itemType) {
        this.itemType = itemType;
    } 
    public void SetItem(InventoryItem item) {
        SetItemImage(item.item.sprite);
        SetQuantity(item.quantity);
        SetItemDescription(item.item.itemName,item.item.description);
        SetItemType(item.item.itemType);
        isEmpty = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(isEmpty)
            return;

        OnItemDrag?.Invoke(this);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnItemEndDrag?.Invoke(this);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(isEmpty) {
            return;
        }
        OnItemBeginDrag?.Invoke(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left) {
            OnItemPointerClick?.Invoke(this);
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        OnItemDrop?.Invoke(this);
    }

    public void ResetItem() {
        descriptionName = "";
        descriptionText = "";
        quantity.text = "";
        itemImage.sprite = null;
        isEmpty = true;
    }

    public void SetItem(string descriptionName, string descriptionText, TextMeshProUGUI quantity, Image image) {
        this.descriptionName = descriptionName;
        this.descriptionText = descriptionText;
        this.quantity.text = quantity.text;
        this.itemImage.sprite = image.sprite;
        isEmpty = false;
    }
}
