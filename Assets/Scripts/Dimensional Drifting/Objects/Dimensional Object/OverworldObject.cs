using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldObject : MonoBehaviour
{
    public Object TargetObject;

    private void Update() {
        if(TargetObject is GameObject) {
            if(!PauseMenu.Instance.Paused) ((GameObject)TargetObject).SetActive(!((DimensionSystem.Instance.Drifted) ? true : false));
        }

        if(TargetObject is Collider2D) {
            if(!PauseMenu.Instance.Paused) ((Collider2D)TargetObject).enabled = !((DimensionSystem.Instance.Drifted) ? true : false);
        }
    }
}
