using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InventorySO : ScriptableObject
{
    public void Initalize() {

    }
}

public struct Inventory 
{
    public int inventorySize;
    public ItemSO item;
    public int quantity;
    public bool isEmpty;

}
