using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PPFXPingPong : MonoBehaviour
{
    public Volume TargetVolume;
    public float MinValue;
    public float MaxValue;

    private void Update() {
        TargetVolume.weight = (Mathf.PingPong(Time.time, (MaxValue - MinValue)) + MinValue);
    }
}
