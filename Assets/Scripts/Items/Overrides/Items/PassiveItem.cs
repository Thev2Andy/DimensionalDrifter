using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItem : Item
{
    // [Header("Item Settings")]

    private void Update() {
       base.CheckInventory();
    }
}
