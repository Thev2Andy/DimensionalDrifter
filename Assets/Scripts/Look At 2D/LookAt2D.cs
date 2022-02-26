using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class LookAt2D : MonoBehaviour
{
    // Private variables..
    private Vector3 LocalScale;

    private void Awake() {
        LocalScale = this.transform.localScale;
    }

    public float PointTorwards(Vector2 Target, float Offset, bool EnableFlipping) {
        Vector3 LookDir = (new Vector3(Target.x, Target.y, 0f) - this.transform.position).normalized;
        float Angle = Mathf.Atan2(LookDir.y, LookDir.x) * Mathf.Rad2Deg + Offset;
        this.transform.eulerAngles = new Vector3(0, 0, Angle);

        if(EnableFlipping) {
            if(Angle > 90f || Angle < -90f) {
                this.transform.localScale = new Vector3(LocalScale.x, -LocalScale.y, LocalScale.z);
            }else {
                this.transform.localScale = LocalScale;
            }
        }

        return Angle;
    }
}
