using UnityEngine;
using System.Collections;

public class PlayerPower : MonoBehaviour
{
    PlayerMovements pMove = new PlayerMovements();
    GameObject powerRadius;

    [SerializeField] Sprite sprite; 

    private void Start()
    {
        powerRadius = new GameObject("PowerRadius");
        renderer = powerRadius.AddComponent<SpriteRenderer>();
        GameObject playerObject = GameObject.Find("player");
        pMove = playerObject.GetComponent<PlayerMovements>();
        
    }
    

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Vector3 playerPos = new Vector3(transform.position.x, transform.position.y, 0f);
            powerRadius.GetComponent<SpriteRenderer>().sprite = sprite;
            Instantiate(powerRadius, playerPos, Quaternion.identity);
        }
    }


}
