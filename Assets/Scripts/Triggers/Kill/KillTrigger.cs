﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D c) {
        if(c.gameObject.CompareTag("Player")) {
            c.gameObject.GetComponentInParent<HealthSystem>().Die();
        }
    }
}
