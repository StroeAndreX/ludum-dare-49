using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Days : MonoBehaviour
{
    /// <summary>
    ///  Invoke all the instances that get update each day pass
    /// </summary>

    HomeBase homeBase;
    private List<Platform> platforms;

    // Days passed...
    public int days = 0;
    int seconds = 0;

    PlayerMoney playerMoney = new PlayerMoney(); 
   

    // Start is called before the first frame update
    void Start()
    {
        platforms = new List<Platform>();
        playerMoney = GameObject.Find("player").GetComponent<PlayerMoney>(); 
        GameObject[] platformsObjects = GameObject.FindGameObjectsWithTag("Platform");
        foreach(GameObject platform in platformsObjects)
        {
            platforms.Add(platform.GetComponent<Platform>());
            Debug.Log("ADD: " + platform.name);
        }

        homeBase = GameObject.Find("HomeBase").GetComponent<HomeBase>();
  
        InvokeRepeating("TimeUntilNewDay", 1f, 1f);  //1s delay, repeat every 1s
     
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            nextDay(); 
        }
    }



    private void nextDay()
    {
        updateList();
        days++; 
        foreach (Platform platform in platforms)
        {
        //    platform.NewDay();
            
        }

        homeBase.NextDay();
    }

    private void updateList()
    {
        platforms.Clear();
        GameObject[] platformsObjects = GameObject.FindGameObjectsWithTag("Platform");
        foreach (GameObject platform in platformsObjects)
        {
            platforms.Add(platform.GetComponent<Platform>());
        }
    }

    void TimeUntilNewDay()
    {
        Debug.Log("...");
        seconds++;

        if (seconds % 10 == 0) playerMoney.currency.changeCryptoValue();
    }

}

