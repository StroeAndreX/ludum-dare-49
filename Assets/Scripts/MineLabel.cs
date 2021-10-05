using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineLabel : MonoBehaviour
{
    [SerializeField] PlatformOptions platformOption = new PlatformOptions();
    [SerializeField] Sprite unlockedLabel;
    [SerializeField] Sprite blockedLabel;

    // Update is called once per frame
    void Update()
    {
        if(platformOption.selectedPlatformLevel < 4 && platformOption.index == 1) this.GetComponent<SpriteRenderer>().sprite = blockedLabel;
        else this.GetComponent<SpriteRenderer>().sprite = unlockedLabel;
    }
}
