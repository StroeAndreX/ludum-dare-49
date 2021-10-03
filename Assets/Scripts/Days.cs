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

    // Start is called before the first frame update
    void Start()
    {
        platforms = new List<Platform>();

        GameObject[] platformsObjects = GameObject.FindGameObjectsWithTag("Platform");
        foreach(GameObject platform in platformsObjects)
        {
            platforms.Add(platform.GetComponent<Platform>());
            Debug.Log("ADD: " + platform.name);
        }

        homeBase = GameObject.Find("HomeBase").GetComponent<HomeBase>();
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
            platform.NewDay();
            
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

}

