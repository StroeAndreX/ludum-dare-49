using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilLabel : MonoBehaviour
{
    [SerializeField] PlatformOptions platformOption = new PlatformOptions();
    [SerializeField] Sprite unlockedLabel;
    [SerializeField] Sprite blockedLabel;

    // Update is called once per frame
    void Update()
    {
        if (platformOption.selectedPlatformLevel < 6 && platformOption.index == 2) this.GetComponent<SpriteRenderer>().sprite = blockedLabel;
        else this.GetComponent<SpriteRenderer>().sprite = unlockedLabel;
    }
}
