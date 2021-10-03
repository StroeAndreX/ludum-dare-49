using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    Currency currency = new Currency(); 
        

    // Start is called before the first frame update
    void Start()
    {
        currency.quantity = 1; 
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currency.conversion());

        if(Input.GetKeyDown(KeyCode.Q)) currency.changeCryptoValue();
    }
}
