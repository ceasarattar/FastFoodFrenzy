using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Order
{
    public List<string> itemsRequired; // The items required for this order

    public Order(List<string> items)
    {
        itemsRequired = items;
    }
}
