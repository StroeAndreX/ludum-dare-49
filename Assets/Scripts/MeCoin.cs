using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MeCoin : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshPro;
    [SerializeField] PlayerMoney playerMoney = new PlayerMoney();

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = this.GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro.text = "Currency: " + playerMoney.currency.quantity + " MeCoin"; 
    }
}
