using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SubtitleController : MonoBehaviour
{
    public TMP_Text SubtitleText;
    // public HealthSystem HS;

    // Singletons..
    public static SubtitleController Instance;

    // Private variables...
    private float Timer;

    private void Awake()
    {
       if (Instance != this && Instance != null) Destroy(Instance);
       Instance = this;
    }

    // Update is called once per frame
    private void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer < 0) Timer = 0;

        if (Timer <= 0 /* || HS.Dead */) SubtitleText.text = "";
    }

    public void Show(string Text, float Time)
    {
        // if(HS.Dead || PauseMenu.Instance.Paused) return;

        SubtitleText.text = Text;
        Timer = Time;
    }
}
