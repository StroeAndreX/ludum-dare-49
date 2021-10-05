using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField] GameObject GameOver;

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

    float SetLevelOfToxicity() => (Random.Range(5, 40)) / homebaseLevel;

    public void IncrementToxicity() => levelOfToxicity += Mathf.Abs(SetLevelOfToxicity());

    public void levelUp() => homebaseLevel++;

    public float DamageToPlayer() => (levelOfToxicity / homebaseLevel);

    private bool gameOver = false;
    private void Update()
    {

        if (homebaseLevel <= 2) spriteRenderer.sprite = imageIndexes[0];
        else if(homebaseLevel > 2 && homebaseLevel <= 4) spriteRenderer.sprite = imageIndexes[1];
        else spriteRenderer.sprite = imageIndexes[2];

        // GameOver
        if (levelOfToxicity >= 100)
        {
            Destroy(GameObject.Find("player"));
            GameOver.SetActive(true);
            gameOver = true;
        }


        if(gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


    }

    public void NextDay()
    {
        IncrementToxicity();
        SetPurificationPrice();
    }



  
}

