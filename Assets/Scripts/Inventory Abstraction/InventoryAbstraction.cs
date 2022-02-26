using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAbstraction : MonoBehaviour
{
    public Item ItemSlot1;

    public Item[] AvalabileItems; // Should be replaced by an item database scriptable object.

    public int CurrentSlot { get; private set; }

    private void Start()
    {
        if(ItemSlot1 != null) ItemSlot1.IsActive = true;
    }

    private void Update()
    {
        for (int i = 0; i < AvalabileItems.Length; i++)
        {
            AvalabileItems[i].IsActive = false;
            AvalabileItems[i].HasItem = false;
        }

        if(ItemSlot1 != null) {
            ItemSlot1.IsActive = true;
            ItemSlot1.HasItem = true;
            ItemSlot1.CheckInventory();
        }
    }

    public void PickupItem(int ID)
    {
        if(ItemSlot1 != null && ItemSlot1.HasItem) {
            ItemSlot1.CreatePickup(new Vector2(ItemSlot1.ItemObject.transform.position.x, ItemSlot1.ItemObject.transform.position.y), Mathf.Abs(ItemSlot1.ItemObject.transform.eulerAngles.z));
            ItemSlot1 = null;
        }

        ItemSlot1 = AvalabileItems[ID];

        if(SubtitleController.Instance != null) SubtitleController.Instance.Show($"{AvalabileItems[ID].ItemName} Acquired.", 1.75f);
    }

    public bool HasAnyItems() {
        return ((ItemSlot1 != null) ? true : false);
    }
}
