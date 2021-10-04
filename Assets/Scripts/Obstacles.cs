using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public int index;
    public Sprite[] sprites;

    private int spriteLength = 0;
    private SpriteRenderer spriteRenderer;

    public float hp = 100;
    private PlayerMoney playerMoney = new PlayerMoney();
    Color originalColor;

    GameObject collideWithPlatform; 
    // Start is called before the first frame update
    void Start()
    {
        spriteLength = sprites.Length;
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color; 
        index = Random.Range(0, spriteLength - 1); 

        spriteRenderer.sprite = sprites[index];
        playerMoney = GameObject.Find("player").GetComponent<PlayerMoney>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(this.gameObject);
            playerMoney.currency.quantity += Random.Range(1.2f, 2f);
            collideWithPlatform.GetComponent<Platform>().platformType = Platform.Type.Normal; 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Platform") collideWithPlatform = collision.gameObject; 
        if (collision.tag == "Bullet") FlashRed();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Platform") collideWithPlatform = collision.gameObject;
    }

        void FlashRed()
    {
        spriteRenderer.color = Color.red;
        Invoke("ResetColor", 0.1f);
    }
    void ResetColor()
    {
        spriteRenderer.color = originalColor;
    }
}
