using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public Currency currency;
    PlayerMovements pMove = new PlayerMovements();

    private bool buyMode = false;
    public GameObject selectedPlatform;

    [SerializeField] private GameObject options;
    private GameObject createOptions;

    public float currentMoney = 0f;

    public float increaseMoney = 0; 

    [SerializeField] GameObject clickHere;

    // Start is called before the first frame update
    void Start()
    {
        currency.quantity = 50;
        pMove = this.GetComponent<PlayerMovements>(); 
    }

    // Update is called once per frame
    void Update()
    {
        currentMoney = currency.conversion();

        if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.Z)) 
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D mouseHit = Physics2D.Raycast(worldPosition, Vector3.zero);

            if(mouseHit.collider != null)
            {
                if(mouseHit.collider.tag == "Platform")
                {
                    selectedPlatform = mouseHit.collider.gameObject; 
                    if(selectedPlatform.GetComponent<Platform>().platformType != Platform.Type.Normal) { return; } 

                    options.SetActive(true);
                    options.transform.position = new Vector3(selectedPlatform.transform.position.x, selectedPlatform.transform.position.y + 1f, options.transform.position.z); // Instantiate(createOptions, selectedPlatform.transform.position, Quaternion.identity); 

                    Destroy(clickHere);
                    buyMode = true;
                } 
            }
        }

    }


    public void ResetFunction()
    {
        //buyMode = false;
        //selectedPlatform = null;

        //options.SetActive(false);
        //Destroy(createOptions);
        Invoke("ResetFunctionCall", 0.01f);
    }

    public void ResetFunctionCall()
    {
        buyMode = false;
        selectedPlatform = null;

        options.SetActive(false);
        Destroy(createOptions);
    }


    public void buyThings(float cost)
    {
        if(currency.quantity > 0)
        {
            currency.quantity -= (cost / currency.crypto_value);
        }
        else
        {
            currency.quantity = 0; 
        }
    }
}
