using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstabilityHomebase : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI textMeshPro;
    [SerializeField] PlayerMoney playerMoney = new PlayerMoney();
    [SerializeField] PlayerMovements pMove = new PlayerMovements();

    HomeBase homebase; 

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = this.GetComponent<TextMeshProUGUI>();
        pMove = GameObject.Find("player").GetComponent<PlayerMovements>();

        homebase = GameObject.Find("HomeBase").GetComponent<HomeBase>(); 
    }

    // Update is called once per frame
    void Update()
    {    
        textMeshPro.text = "Homebase Instability " + homebase.levelOfToxicity.ToString("00") + "%"; 
    }
}
