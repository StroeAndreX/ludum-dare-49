using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBase : MonoBehaviour
{
    public float levelOfToxicity = 0.4f;
    public int homebaseLevel = 1;

    private float powerUpPrice = 55f;
    private int percentOfInfection = 75;

    private float purificationPrice = 10f;

    void DebugDisplay()
    {
        Debug.Log("Toxicity: " + levelOfToxicity.ToString());
        Debug.Log("HomeBase Level: " + homebaseLevel.ToString());
        Debug.Log("CostForPowerUP: " + powerUpPrice.ToString());
        Debug.Log("percentOfInfection: " + percentOfInfection.ToString());
        Debug.Log("costForPurification: " + purificationPrice.ToString());
    }

    float setPowerUpCost() => powerUpPrice + (homebaseLevel * powerUpPrice);

    float setPurificationPrice() => levelOfToxicity * ((purificationPrice * 2) / homebaseLevel);

    float setLevelOfToxicity() => (percentOfInfection / Random.Range(1, 6)) / homebaseLevel;

    void nextDay() => levelOfToxicity += setLevelOfToxicity();

    public float damageToPlayer() => (levelOfToxicity / homebaseLevel);

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            homebaseLevel += 1;
            powerUpPrice = setPowerUpCost();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            nextDay();
            setPurificationPrice();
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            levelOfToxicity = 0f; 
        }

        // if(Input.anyKeyDown) DebugDisplay();


    }
}
