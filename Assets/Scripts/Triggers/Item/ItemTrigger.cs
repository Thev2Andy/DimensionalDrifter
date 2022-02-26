using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    public int ItemPickupID;
    public bool ForceItemPickup;

    // Private variables..
    private float JumpTimer;

    private void Start() {
        if(this.TryGetComponent<Rigidbody2D>(out Rigidbody2D RB)) {
            RB.sleepMode = RigidbodySleepMode2D.NeverSleep;
        }
    }

    private void OnTriggerStay2D(Collider2D c) {
        if(PauseMenu.Instance.Paused) return;

        if(c.gameObject.CompareTag("Player")) {
            if(!c.gameObject.GetComponentInChildren<InventoryAbstraction>().HasAnyItems() || Input.GetKeyDown(KeyCode.E) || ForceItemPickup) {
                c.gameObject.GetComponentInChildren<InventoryAbstraction>().PickupItem(ItemPickupID);
                Destroy(gameObject);
            }else {
                if(this.TryGetComponent<Rigidbody2D>(out Rigidbody2D RB) && JumpTimer <= 0f) {
                    RB.velocity = Vector2.zero;
                    RB.angularVelocity = 0f;
                    RB.AddForce(new Vector2(0, 95));
                    float Torque = Random.Range(-1f, 1f);
                    RB.AddTorque((15f * ((Torque != 0) ? Torque : 1f)));
                    JumpTimer = System.UInt64.MaxValue;
                }
            }
        }
    }

    private void Update() {
        if(JumpTimer < 0f) JumpTimer = 0f;
        JumpTimer -= Time.deltaTime;
    }

    private void OnTriggerExit2D(Collider2D c) {
        if(c.gameObject.CompareTag("Player")) {
            JumpTimer = 0.95f;
        }
    }
}
