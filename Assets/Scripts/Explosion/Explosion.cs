using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float ExplosionForce;
    public float ExplosionRange;

    // Private / Hidden variables..
    [HideInInspector] public bool Exploded;

    private void Start() {
        Explode();
    }

    private void Update() {
        if(Exploded) gameObject.SetActive(false);
    }

    public void Explode()
    {
        Collider2D[] Hits = Physics2D.OverlapCircleAll(transform.position, ExplosionRange);

        foreach (Collider2D Hit in Hits)
        {
            if (Hit.gameObject.GetComponent<Rigidbody2D>()) {
                Rigidbody2DExtension.AddExplosionForce(Hit.gameObject.GetComponent<Rigidbody2D>(), ExplosionForce, this.transform.position, ExplosionRange);
            }
        }

        Destroy(gameObject, 3.5f);
    }

    private void OnDrawGizmosSelected() {
        if(ExplosionRange > 0) Gizmos.DrawWireSphere(this.transform.position, ExplosionRange);
    }
}
