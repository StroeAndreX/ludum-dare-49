using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public float quantity = 0; 
    public float crypto_value = 0.24f;
    public float percentuage = 0;

    private void Update() {
        Debug.Log(crypto_value);
    }

    public void changeCryptoValue()
    {
        int generateProbability = Random.Range(0, 100);

        if (generateProbability > 50)
        {
            percentuage = +Random.Range(0.05f, 0.2f);
            crypto_value += (crypto_value * percentuage);
        }
        else
        {
            percentuage = -Random.Range(0.05f, 0.2f);
            if(crypto_value > 0.10f)
            {
                crypto_value += (crypto_value * percentuage); 
            }
            if(crypto_value < 0) crypto_value = 0.10f;
        }
    }

    public float conversion() => quantity * crypto_value; 

}
