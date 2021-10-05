using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Productivity : MonoBehaviour
{
    public Sprite[] sprites; // 0, 1, 2
    public Platform.Type type;
    public int index; 


    private SpriteRenderer spriteRenderer;
    private PlayerMoney playerMoney = new PlayerMoney(); 
    // Start is called before the first frame update
    void Start()
    {
        

    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.zero);
        //if(hit.collider.tag != "Platform" && hit.collider.tag != "Untagged") Destroy(this.gameObject);
         if(hit.collider.tag == null) Destroy(this.gameObject);
        //spriteRenderer = GetComponent<SpriteRenderer>();

        //if (type == Platform.Type.Farm) spriteRenderer.sprite = sprites[Random.Range(0,2)];
        //else if (type == Platform.Type.Mine) spriteRenderer.sprite = sprites[3];
        //else if (type == Platform.Type.Oil) spriteRenderer.sprite = sprites[5];
        //else if (type == Platform.Type.House) spriteRenderer.sprite = sprites[4];
    }
}

/*
 * 
 *         spriteRenderer = GetComponent<SpriteRenderer>();

        if (index == 0)
        {
            type = Platform.Type.Farm;
            spriteRenderer.sprite = sprites[1];
            playerMoney.increaseMoney += Random.Range(0.2f, 0.9f);
        }
        else if (index == 1)
        {
            type = Platform.Type.Mine;
            spriteRenderer.sprite = sprites[3];
            playerMoney.increaseMoney += Random.Range(0.8f, 2f);
        }
        else if (index == 2)
        {
            type = Platform.Type.Oil;
            spriteRenderer.sprite = sprites[4];
            playerMoney.increaseMoney += Random.Range(1.6f, 7f);
        }
        else
        {
            type = Platform.Type.House;
            spriteRenderer.sprite = sprites[5];
            playerMoney.increaseMoney += Random.Range(7f, 20f);
        }*
*
*/