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

    float SetPowerUpCost() => powerUpPrice + (homebaseLevel * powerUpPrice);

    float SetPurificationPrice() => levelOfToxicity * ((purificationPrice * 2) / homebaseLevel);

    float SetLevelOfToxicity() => (percentOfInfection / Random.Range(1, 6)) / homebaseLevel;

    void IncrementToxicity() => levelOfToxicity += SetLevelOfToxicity();

    public float DamageToPlayer() => (levelOfToxicity / homebaseLevel);

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            homebaseLevel += 1;
            powerUpPrice = SetPowerUpCost();
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            levelOfToxicity = 0f; 
        }
    }

    public void NextDay()
    {
        IncrementToxicity();
        SetPurificationPrice();
    }
}

