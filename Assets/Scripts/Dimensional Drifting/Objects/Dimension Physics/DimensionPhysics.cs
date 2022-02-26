using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionPhysics : MonoBehaviour
{
    public Vector2 DimensionGravity;

    // Private variables..
    private Vector2 OriginalGravity;

    private void Awake() {
        OriginalGravity = Physics2D.gravity;
    }

    private void Update() {
        if(!PauseMenu.Instance.Paused) Physics2D.gravity = ((DimensionSystem.Instance.Drifted) ? DimensionGravity : OriginalGravity);
    }
}
