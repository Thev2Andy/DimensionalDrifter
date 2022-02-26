using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionTime : MonoBehaviour
{
    public float DimensionTimeScale;
    public float DimensionFixedTimeStep;

    // Private variables..
    private float OriginalTimeScale;
    private float OriginalFixedTimeStep;

    private void Awake() {
        OriginalTimeScale = Time.timeScale;
        OriginalFixedTimeStep = Time.fixedDeltaTime;
    }

    private void Update() {
        if(!PauseMenu.Instance.Paused) Time.timeScale = ((DimensionSystem.Instance.Drifted) ? DimensionTimeScale : OriginalTimeScale);
        if(!PauseMenu.Instance.Paused) Time.fixedDeltaTime = ((DimensionSystem.Instance.Drifted) ? DimensionFixedTimeStep : OriginalFixedTimeStep);
    }
}
