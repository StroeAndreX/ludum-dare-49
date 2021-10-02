using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class building_script : MonoBehaviour
{
    PlayerMovements pMove = new PlayerMovements();

    private void Start()
    {
        GameObject playerObject = GameObject.Find("player");
        pMove = playerObject.GetComponent<PlayerMovements>(); 
    }

    // Update is called oncPlayerMovementse per frame
    private void Update()
    {
        
    }
}
