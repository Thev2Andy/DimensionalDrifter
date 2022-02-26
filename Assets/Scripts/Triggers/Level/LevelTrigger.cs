using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D c)
    {
        HealthSystem HS = c.gameObject.GetComponentInParent<HealthSystem>();
        if (c.gameObject.CompareTag("Player") && HS != null)
        {
            if (HS.IsDead) return;

            HS.LevelUI.SetActive(true);
            PauseMenu.Instance.Pause();
            PauseMenu.Instance.PauseUI.SetActive(false);
            Destroy(this);
        }
    }
}
