using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Item
{
    [Header("Weapon Settings")]
    public GameObject MuzzleFlash;
    public AudioClip ShootSound;
    public float Range;
    public float ImpactForce;
    public GameObject ImpactEffect;
    public Transform FirePoint;
    public float BulletForce;


    [Header("Look Settings")]
    public Camera LookCamera;
    public LookAt2D Look;
    public float LookOffset;
    
    private void Update() {
        base.CheckInventory();

        if(PauseMenu.Instance.Paused) return;
        if(HasItem && IsActive) {
            Look.PointTorwards(LookCamera.ScreenToWorldPoint(Input.mousePosition), LookOffset, true);

            if(Input.GetKeyDown(KeyCode.Mouse0)) Shoot();
        }
    }

    public void Shoot()
    {
        RaycastHit2D Hit = Physics2D.Raycast(FirePoint.position, FirePoint.up);

        if(Hit)
        {
            if(Hit.rigidbody != null) {
                Hit.rigidbody.AddForceAtPosition(-(Hit.normal * ImpactForce), Hit.point);
            }

            Debug.DrawLine(FirePoint.position, Hit.point);
        }

        Camera.main.GetComponent<AudioSource>()?.PlayOneShot(ShootSound);
        MuzzleFlash.SetActive(true);
    }
}
