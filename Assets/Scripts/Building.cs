using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    PlayerMovements pMove = new PlayerMovements();
    public GameObject buildPlatform; 
    float unit = 2f;

    private Vector3 newPlatformPosition;
    private bool build;

    [SerializeField] private GameObject prePlatform; 

    private void Start()
    {
        prePlatform = Instantiate(prePlatform, newPlatformPosition, Quaternion.identity);

        GameObject playerObject = GameObject.Find("player");
        pMove = playerObject.GetComponent<PlayerMovements>(); 
    }

    // Update is called oncPlayerMovementse per frame
    private void Update()
    {
        if (pMove.inputX != 0 || pMove.inputY != 0) RayHitBuiding();

        if(build)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                Vector3 newBuild = new Vector3(pMove.sittingPlatform.transform.position.x + (unit * newPlatformPosition.x), pMove.sittingPlatform.transform.position.y + (unit * newPlatformPosition.y), 0f);
                Instantiate(buildPlatform, newBuild, Quaternion.identity);

                resetBuilding();
            }
        }
    }

    void RayHitBuiding()
    {
        Vector3 origin = new Vector3(transform.position.x + (1.2f * pMove.inputX), transform.position.y + (1.2f * pMove.inputY), 0f);
        Vector3 direction = new Vector3(pMove.inputX, pMove.inputY, 0f);

        RaycastHit2D hit = Physics2D.Raycast(origin, direction, 0f);
        Debug.DrawRay(origin, direction, Color.red, 1.0f);
        Vector3 newBuild = new Vector3(pMove.sittingPlatform.transform.position.x + (unit * newPlatformPosition.x), pMove.sittingPlatform.transform.position.y + (unit * newPlatformPosition.y), 0f);

        prePlatform.transform.position = newBuild;


        if (hit.collider != null) resetBuilding(); 
        else configBuildingInfo();
    }

    void configBuildingInfo()
    {
        build = true;
        newPlatformPosition = new Vector3(pMove.inputX, pMove.inputY, 0f);
        


        Debug.Log("Hello World");
    }

    void resetBuilding()
    {
        build = false;
        newPlatformPosition = new Vector3();
        // prePlatform.transform.position = newPlatformPosition; 
        //Destroy(prePlatform);
    }

}
