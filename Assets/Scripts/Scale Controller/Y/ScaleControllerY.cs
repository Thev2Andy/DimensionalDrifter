using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleControllerY : MonoBehaviour
{
    public Transform RelatveObject;

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.localScale = new Vector3(transform.localScale.y, (RelatveObject.localScale.y / Mathf.Abs(RelatveObject.localScale.y) * transform.localScale.z), transform.localScale.z);
    }
}
