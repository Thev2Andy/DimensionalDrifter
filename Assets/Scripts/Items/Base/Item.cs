using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [Header("Inventory Settings")]
    public string ItemName;
    public GameObject PickupPrefab;
    public GameObject ItemObject;
    public Rigidbody2D PlayerRB;
    public bool IsActive = true;
    public bool HasItem;
    
    public virtual void CheckInventory() {
        ItemObject.SetActive((HasItem && IsActive));
    }

    public virtual void CreatePickup(Vector2 Position, float Rotation) {
        Rigidbody2D Pickup = Instantiate(PickupPrefab, Vector3.zero, Quaternion.identity).GetComponent<Rigidbody2D>();

        if(Pickup != null) {
            if(PlayerRB != null) Pickup.velocity = (PlayerRB.velocity * 0.45f);
            Pickup.AddForce(new Vector2(0f, 175f));

            float Torque = Random.Range(-1f, 1f);
            Pickup.AddTorque((17.5f * ((Torque != 0) ? Torque : 1f)));

            Pickup.position = Position;
            Pickup.rotation = Rotation;
        }
    }
}
