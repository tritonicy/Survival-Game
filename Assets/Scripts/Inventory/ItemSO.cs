using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public enum ItemType{
        Edible,
        Block,
        Wearable
    }
    
[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    [field: SerializeField] public Sprite sprite { get; set; }
    [field:SerializeField] public int quantity{get; set;}
    [field:SerializeField] public string itemName {get; set;}
    [field:SerializeField] [field:TextArea] public string description{get; set;}
    [field:SerializeField] public ItemType itemType;
}
