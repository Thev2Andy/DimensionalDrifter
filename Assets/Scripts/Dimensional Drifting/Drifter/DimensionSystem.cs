using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionSystem : MonoBehaviour
{
    public GameObject DimensionalFX;
    public GameObject SwapFlash;
    public AudioClip SwapSound;
    public float Duration;
    public float Cooldown;

    // Singletons
    public static DimensionSystem Instance;

    // Private / Hidden variables..
    [HideInInspector] public bool Drifted;
    private float CooldownTimer;
    private float DurationTimer;


    private void Awake()
    {
       if (Instance != this && Instance != null) Destroy(Instance);
       Instance = this;
    }

    private void Update() {
        if(!PauseMenu.Instance.Paused) {
            if(Input.GetKeyDown(KeyCode.X) && !this.GetComponent<HealthSystem>().IsDead) {
                if(CooldownTimer <= 0f && !this.GetComponent<HealthSystem>().IsDead || Drifted && !this.GetComponent<HealthSystem>().IsDead) {
                    SwapDimension();
                }else if(!this.GetComponent<HealthSystem>().IsDead) {
                    if(SubtitleController.Instance != null) SubtitleController.Instance.Show($"Dimensions on cooldown..", 1.75f);
                }
            }

            if(CooldownTimer < 0f) CooldownTimer = 0f;
            CooldownTimer -= Time.deltaTime;

            if(Drifted) {
                DurationTimer += Time.deltaTime;
                if(DurationTimer >= Duration) {
                    if(SubtitleController.Instance != null) SubtitleController.Instance.Show($"oh snap", 1.75f);
                    CooldownTimer = Cooldown * 3f;
                    DurationTimer = 0f;
                    SwapDimension();
                }
            }else {
                DurationTimer = 0f;
            }
        }
    }

    public void SwapDimension() {
        Drifted = !Drifted;
        CooldownTimer = Cooldown;

        DimensionalFX.SetActive(Drifted);
        SwapFlash.SetActive(true);
        Camera.main.GetComponent<AudioSource>().PlayOneShot(SwapSound);
    }
}
