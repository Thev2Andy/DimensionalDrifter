using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Item
{
    [Header("Weapon Settings")]
    public Animator WeaponAnimator;
    public TrailRenderer BladeTrail;
    public AudioClip SwooshSound;
    public Transform AttackPoint;
    public float AttackRange;
    public float ImpactForce;
    public LayerMask AttackMask;

    private void Update() {
        base.CheckInventory();

        if(PauseMenu.Instance.Paused) return;
        if(HasItem && IsActive)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0)) {
                Attack();
            }
        }
    }

    public void Attack() {
        Collider2D[] Hits = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, AttackMask);
        WeaponAnimator.SetTrigger("Attack");
        BladeTrail.gameObject.SetActive(true);
        Camera.main.GetComponent<AudioSource>()?.PlayOneShot(SwooshSound);

        foreach (Collider2D Hit in Hits)
        {
            if (Hit.gameObject.GetComponent<Rigidbody2D>())
            {
                Rigidbody2DExtension.AddExplosionForce(Hit.gameObject.GetComponent<Rigidbody2D>(), -ImpactForce, this.transform.position, AttackRange);
            }

            if(Hit.gameObject.GetComponent<FlyingEnemy>()) 
            {
                Hit.gameObject.GetComponent<FlyingEnemy>().Die();
            }
        }
    }

    private void OnDrawGizmosSelected() {
        if(AttackPoint != null && AttackRange > 0) Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
}
