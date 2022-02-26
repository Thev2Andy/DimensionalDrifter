using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyingEnemy : MonoBehaviour
{
    public GameObject ExplosionEffect;
    public AIPath Path;
    public AIDestinationSetter Targeter;

    private void Start() {
        Targeter.target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.CompareTag("Player") && Targeter.target != null)
        {
            c.gameObject.GetComponentInParent<HealthSystem>().Die();
            this.Die();

            if(ExplosionEffect != null) Instantiate(ExplosionEffect, this.transform.position, this.transform.rotation);
        }
    }

    private void Update() {
        this.transform.localScale = new Vector3((Mathf.Abs(this.transform.localScale.x) * ((Path.desiredVelocity.x > 0) ? 1f : -1f)), this.transform.localScale.y, this.transform.localScale.z);
    }

    public void Die() {
        Rigidbody2D RB = this.GetComponent<Rigidbody2D>();
        if(RB != null) {
            RB.constraints = RigidbodyConstraints2D.None;
            RB.velocity = Path.desiredVelocity;
        }

        Destroy(Targeter);
        Destroy(Path);
        Destroy(this.GetComponent<Seeker>());

        this.gameObject.layer = LayerMask.NameToLayer("Debris");
        Destroy(this);
    }
}
