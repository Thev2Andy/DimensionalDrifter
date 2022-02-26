using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointFlipper : MonoBehaviour
{
    public CharacterController2D Player;

    // Update is called once per frame
    private void Update() {
        transform.localEulerAngles = new Vector3(0f, 0f, ((Player.m_FacingRight) ? 0f : 180f));
    }
}
