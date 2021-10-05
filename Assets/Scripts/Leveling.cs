using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Leveling : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI textMeshPro;
    [SerializeField] PlayerMoney playerMoney = new PlayerMoney();
    [SerializeField] PlayerMovements pMove = new PlayerMovements();

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = this.GetComponent<TextMeshProUGUI>();
        pMove = GameObject.Find("player").GetComponent<PlayerMovements>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pMove.sittingPlatform.tag != null && pMove.sittingPlatform.tag == "Platform")
        {
            Platform platform = pMove.sittingPlatform.GetComponent<Platform>();
            textMeshPro.text = "Platform Level " + platform.levelOfStability;
        }

        if (pMove.sittingPlatform.tag != null && pMove.sittingPlatform.tag == "Homebase")
        {
            HomeBase homeBase = pMove.sittingPlatform.GetComponent<HomeBase>();
            textMeshPro.text = "Homebase Level " + homeBase.homebaseLevel;
        }
    }
}
