using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBase : MonoBehaviour
{
    public float levelOfToxicity = 0.4f;
    public int homebaseLevel = 1;

    private float powerUpPrice = 5.5f;
    private int percentOfInfection = 75;

    public float purificationPrice = 0.5f;

    /// <summary>
    ///  Sprite / Graphics
    /// </summary>

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] imageIndexes; 


    private void Start()
    {
        spriteRenderer.sprite = imageIndexes[0];
    }

    void DebugDisplay()
    {
        Debug.Log("Toxicity: " + levelOfToxicity.ToString());
        Debug.Log("HomeBase Level: " + homebaseLevel.ToString());
        Debug.Log("CostForPowerUP: " + powerUpPrice.ToString());
        Debug.Log("percentOfInfection: " + percentOfInfection.ToString());
        Debug.Log("costForPurification: " + purificationPrice.ToString());
    }

    public float SetPowerUpCost() => powerUpPrice + (homebaseLevel * powerUpPrice);

    public float SetPurificationPrice() => levelOfToxicity * ((purificationPrice * 2) / homebaseLevel);

    float SetLevelOfToxicity() => (percentOfInfection / Random.Range(1, 6)) / homebaseLevel;

    public void IncrementToxicity() => levelOfToxicity += SetLevelOfToxicity();

    public void levelUp() => homebaseLevel++;

    public float DamageToPlayer() => (levelOfToxicity / homebaseLevel);

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    homebaseLevel += 1;
        //    powerUpPrice = SetPowerUpCost();
        //}

        //if(Input.GetKeyDown(KeyCode.P))
        //{
        //    levelOfToxicity = 0f; 
        //}

        if (homebaseLevel <= 2) spriteRenderer.sprite = imageIndexes[0];
        else if(homebaseLevel > 2 && homebaseLevel <= 4) spriteRenderer.sprite = imageIndexes[1];
        else spriteRenderer.sprite = imageIndexes[2];

    }

    public void NextDay()
    {
        IncrementToxicity();
        SetPurificationPrice();
    }

  
}

