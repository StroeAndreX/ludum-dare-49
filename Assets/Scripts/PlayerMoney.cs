using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public Currency currency;
    PlayerMovements pMove = new PlayerMovements();

    // Start is called before the first frame update
    void Start()
    {
        currency.quantity = 1;
        pMove = this.GetComponent<PlayerMovements>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currency.conversion());

        if(Input.GetKeyDown(KeyCode.Q)) currency.changeCryptoValue();
        if (Input.GetKeyDown(KeyCode.P)) transformPlatform(); 
    }

    public void transformPlatform()
    {
        pMove.sittingPlatform.GetComponent<Platform>().transformPlatform(Platform.Type.Mine);
    }
}
