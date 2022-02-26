using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class HealthSystem : MonoBehaviour
{
    public GameObject PlayerRagdoll;
    public CinemachineVirtualCamera PlayerCamera;
    public Rigidbody2D PlayerController;
    public GameObject DeathUI;
    public GameObject LevelUI;

    // Private / Hidden variables..
    [HideInInspector] public bool IsDead;

    // Allows the script to be disabled using the checkbox..
    private void Update() {
        // // Test binds..
        // if(Input.GetKeyDown(KeyCode.K) && !PauseMenu.Instance.Paused) Die();
    }

    public void Die()
    {
        if(this.enabled != true || IsDead) return;
        IsDead = true;

        if(this.GetComponent<DimensionSystem>() != null && this.GetComponent<DimensionSystem>().Drifted) this.GetComponent<DimensionSystem>().SwapDimension();

        GameObject Ragdoll = Instantiate(PlayerRagdoll, PlayerController.transform.position, PlayerController.transform.rotation);
        Ragdoll.transform.localScale = PlayerController.transform.localScale;

        PlayerController.GetComponentInChildren<InventoryAbstraction>().ItemSlot1?.CreatePickup(new Vector2(PlayerController.GetComponentInChildren<InventoryAbstraction>().ItemSlot1.ItemObject.transform.position.x, PlayerController.GetComponentInChildren<InventoryAbstraction>().ItemSlot1.ItemObject.transform.position.y), Mathf.Abs(PlayerController.GetComponentInChildren<InventoryAbstraction>().ItemSlot1.ItemObject.transform.eulerAngles.z));

        Rigidbody2D[] RagdollRBs = Ragdoll.GetComponentsInChildren<Rigidbody2D>();
        for (int i = 0; i < RagdollRBs.Length; i++) {
            RagdollRBs[i].velocity = (PlayerController.velocity / 1.65f);
        }

        PlayerCamera.m_Follow = Ragdoll.transform.GetChild(0);

        DeathUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Destroy(PlayerController.gameObject);
    }
}
