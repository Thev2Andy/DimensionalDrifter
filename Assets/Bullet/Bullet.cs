using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public int MaxBounces;
    public Vector2 CenterOfMass;

    // Private variables..
    private int Bounces;

    private void Start() {
        Rigidbody2D RB = this.GetComponent<Rigidbody2D>();
        RB.centerOfMass = CenterOfMass;
    }

    private void OnCollisionEnter2D(Collision2D c) {
        if(Bounces > 0) Destroy(this.GetComponent<TrailRenderer>());

        if(Bounces >= MaxBounces && MaxBounces >= 0) Destroy(gameObject);
        if(MaxBounces >= 0) Bounces += 1;
    }
}
