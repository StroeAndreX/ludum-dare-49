using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformOptions : MonoBehaviour
{
    public int index;
    // 0: Farm
    // 1: Mine
    // 2: Oil
    // 3: House

    public Sprite[] sprites; 
    private SpriteRenderer spriteRenderer;

    private PlayerMoney pMoney = new PlayerMoney();
    private int selectedPlatformLevel; 
       

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[index];

        pMoney = GameObject.Find("player").GetComponent<PlayerMoney>();

        //selectedPlatformLevel = pMoney.selectedPlatform.GetComponent<Platform>().levelOfStability;
        //if(selectedPlatformLevel < 4 && index == 1) spriteRenderer.sprite = sprites[4];
        //else if (selectedPlatformLevel < 6 && index == 2) spriteRenderer.sprite = sprites[4];
        //else if (selectedPlatformLevel < 10 && index == 3) spriteRenderer.sprite = sprites[4];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D mouseHit = Physics2D.Raycast(worldPosition, Vector3.zero, 0f);

        if(mouseHit.collider != null)
        {

            if (mouseHit.collider.gameObject == this.gameObject)
            
                this.spriteRenderer.color = Color.yellow;
            
            else
                this.spriteRenderer.color = Color.white;

        }

        Debug.Log(pMoney.selectedPlatform);
        if(pMoney.selectedPlatform != null)
        {
            Platform platform = pMoney.selectedPlatform.GetComponent<Platform>();
            Debug.Log("Debug Log Level: " + platform.levelOfStability);
            selectedPlatformLevel = platform.levelOfStability;

            if (selectedPlatformLevel < 4 && index == 1) spriteRenderer.sprite = sprites[4];
            else if (selectedPlatformLevel < 6 && index == 2) spriteRenderer.sprite = sprites[4];
            else if (selectedPlatformLevel < 10 && index == 3) spriteRenderer.sprite = sprites[4];
            else spriteRenderer.sprite = sprites[index];


        }
        


    }
}
