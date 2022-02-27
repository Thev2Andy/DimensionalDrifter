using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpilepsyWarning : MonoBehaviour
{
    public GameObject EpilepsyScreen;

    private void Awake() {
        if(PlayerPrefs.GetInt("EpilepsyWarning", 0) == 1) {
            EpilepsyScreen.SetActive(false);
            return;
        }

        PlayerPrefs.SetInt("EpilepsyWarning", 1);
    }
}
