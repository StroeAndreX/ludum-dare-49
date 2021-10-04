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

    // Start is called before the first frame update
    void Start()
    {
        currency.quantity = 1;
        pMove = this.GetComponent<PlayerMovements>(); 
    }

    // Update is called once per frame
    void Update()
    {
        currentMoney = currency.conversion();

        if (Input.GetKeyDown(KeyCode.Q)) currency.changeCryptoValue();
        if (Input.GetKeyDown(KeyCode.P)) transformPlatform();

        if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.Z))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D mouseHit = Physics2D.Raycast(worldPosition, Vector3.zero);

            if(mouseHit.collider != null)
            {
                if(mouseHit.collider.tag == "Platform")
                {
                    selectedPlatform = mouseHit.collider.gameObject; 
                    options.SetActive(true);
                    options.transform.position = new Vector3(selectedPlatform.transform.position.x, selectedPlatform.transform.position.y + 1f, options.transform.position.z); // Instantiate(createOptions, selectedPlatform.transform.position, Quaternion.identity); 

                    buyMode = true;
                } 
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            buyMode = false;
            selectedPlatform = null;

            options.SetActive(false);
            Destroy(createOptions);
        }
    }

    public void buyThings(float cost)
    {
        currency.quantity -= (cost / currency.crypto_value);
    }

    public void transformPlatform()
    {
        pMove.sittingPlatform.GetComponent<Platform>().TransformPlatform(Platform.Type.Mine);
    }
}
