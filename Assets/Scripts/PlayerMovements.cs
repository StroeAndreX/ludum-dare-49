using System;
using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovements : MonoBehaviour
{
    float speed = 2f;
    Vector3 movement;

    public int inputX { get; set; } 
    public int inputY { get; set; }

    public GameObject sittingPlatform;

    // Player Attack
    public GameObject playerBullet;
    private Platform sittingPlatformClass;

    // Update is called once per frame
    void Update()
    {
        int _kCodeA = -Convert.ToInt16(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow));
        int _kCodeD = Convert.ToInt16(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow));
        int _kCodeW = Convert.ToInt16(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow));
        int _kCodeS = -Convert.ToInt16(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow));

        inputX = (_kCodeA + _kCodeD);
        inputY = (_kCodeW + _kCodeS);

        Debug.Log(inputX);
        movement = new Vector3(speed * inputX, speed * inputY, 0);
        if (RayHitWithPlatform()) transform.position += movement * Time.deltaTime;

        // Player Attack
        if(Input.GetKeyDown(KeyCode.X)) Instantiate(playerBullet, transform.position, Quaternion.identity);

        if(sittingPlatform != null && sittingPlatform.tag == "Platform")
        {
            // PowerUp Platform
            powerUpPlatform();

            // Repair platform
            repairPlatform(); 
        }
        else if(sittingPlatform != null && sittingPlatform.tag == "Homebase" )
      
        {
            // PowerUp HomeBase
            levelUpHomebase();

            // Repair HomeBase
            purifyHomebase();
        }

    }

    bool RayHitWithPlatform() {
        //Vector3 rayCast = new Vector3(0.3f * inputX, 0.3f * inputY, 0);
        Vector3 origin = new Vector3(transform.position.x + (0.1f * inputX), transform.position.y + (0.1f * inputY), 0f);
        Vector3 direction = new Vector3(0.1f * inputX, 0.1f * inputY, 0f);

        RaycastHit2D hit = Physics2D.Raycast(origin, direction, 0.0f);
        Debug.DrawRay(origin, direction,  Color.green, 1.0f);

        if (hit.collider.tag == "Platform" || hit.collider.tag == "Homebase")
        {
            sittingPlatform = hit.collider.gameObject;
            return true;
        }
        else return false;
    }

    private void repairPlatform()
    {
        Platform platform = sittingPlatform.GetComponent<Platform>();
        PlayerMoney playerMoney = this.GetComponent<PlayerMoney>();

        if(Input.GetKeyDown(KeyCode.Q) && playerMoney.currency.conversion() > 0.25f)
        {
            platform.levelOfRisk -= 20;
            if (platform.levelOfRisk < 0) platform.levelOfRisk = 0;


            playerMoney.buyThings(0.25f);
        }
    }

    private void powerUpPlatform()
    {
        Platform platform = sittingPlatform.GetComponent<Platform>();
        PlayerMoney playerMoney = this.GetComponent<PlayerMoney>();

        if (Input.GetKeyDown(KeyCode.E) && playerMoney.currency.conversion() > (0.50f * platform.levelOfStability))
        {
            platform.levelOfStability++;

            playerMoney.buyThings(0.50f * platform.levelOfStability) ;
        }
    }

    private void purifyHomebase()
    {
        HomeBase homeBase = sittingPlatform.GetComponent<HomeBase>();
        PlayerMoney playerMoney = this.GetComponent<PlayerMoney>();

        if (Input.GetKeyDown(KeyCode.Q) && playerMoney.currency.conversion() > homeBase.purificationPrice)
        {
            float price = homeBase.purificationPrice; 
            playerMoney.buyThings(price);

            homeBase.levelOfToxicity = 0;
            
        }
        
    }

    private void levelUpHomebase()
    {
        HomeBase homeBase = sittingPlatform.GetComponent<HomeBase>();
        PlayerMoney playerMoney = this.GetComponent<PlayerMoney>();

        if (Input.GetKeyDown(KeyCode.E) && playerMoney.currency.conversion() > homeBase.SetPowerUpCost())
        {
            float price = homeBase.SetPowerUpCost(); 
            playerMoney.buyThings(price);

            homeBase.homebaseLevel++;

        }
    }


}


