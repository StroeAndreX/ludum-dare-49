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
    public int nextToxicity = 0;
    int secondsUntilCrypto = 0;
    int secondsUntilToxicity = 0;

    public int secondsRemain = 30; 

    PlayerMoney playerMoney = new PlayerMoney();
    private GameObject homeBaseObject;

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
        homeBaseObject = GameObject.Find("HomeBase");
        homeBase = homeBaseObject.GetComponent<HomeBase>();
  
        InvokeRepeating("CryptoChange", 1f, 1f);  //1s delay, repeat every 1s
        InvokeRepeating("ToxicityChange", 1f, 1f);  //1s delay, repeat every 1s
        InvokeRepeating("IncreaseMoney", 1f, 1f);  //1s delay, repeat every 1s
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.L))
        // {
        //    nextDay(); 
        // }
    }



    private void nextDay()
    {
        updateList();
        foreach (Platform platform in platforms)
        {
            platform.NewDay();       
        }

        homeBase.NextDay();

        secondsRemain = Random.Range(15, 45);


        GameObject player = GameObject.Find("player");
        player.transform.position = new Vector3(homeBaseObject.transform.position.x, homeBaseObject.transform.position.y, player.transform.position.z - 3);
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

    void CryptoChange()
    {
        Debug.Log("...");
        secondsUntilCrypto++;

        if (secondsUntilCrypto % 1.5 == 0) playerMoney.currency.changeCryptoValue();
    }


    void ToxicityChange()
    {
        Debug.Log("...");
        secondsRemain--;

        if (secondsRemain <= 0) nextDay(); 
    }

    void IncreaseMoney()
    {
        playerMoney.currency.quantity += (playerMoney.increaseMoney / 30);
    }

}


