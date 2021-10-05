using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public enum Type { Farm, Mine, Oil, House, Normal, Dangerous};

    public int levelOfRisk = 10;
    public Type platformType = Type.Normal;

    public int levelOfStability = 1; // 7: Max Stability. 

    private PlayerMoney playerMoney;

    /// <summary>
    ///  Sprite management
    /// </summary>

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] imageIndexes;
    [SerializeField] private GameObject waterEffect;
    [SerializeField] private GameObject obstacle;
    [SerializeField] private GameObject productivity;

    [SerializeField] private Sprite[] typeRenderer;


    private Vector3 initPositionWater;
    private Vector3 initScaleWater;

    RaycastHit2D obstacleHit;

    private GameObject builtX;

    /// GameObject canvas
    public GameObject info;


    private void Start()
    {
        levelOfRisk = Random.Range(1, 99);
        playerMoney = GameObject.Find("player").GetComponent<PlayerMoney>();
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (transform.position.y / 10));
        spriteRenderer.sprite = imageIndexes[0];

        initPositionWater = waterEffect.transform.position;
        initScaleWater = waterEffect.transform.localScale;

        platformType = Type.Normal;
    }

    private void Update()
    {
        obstacleHit = Physics2D.Raycast(transform.position, Vector3.zero);
        RayHitBuiding();

        if(platformType == Type.Dangerous && obstacleHit.collider.tag != "Obstacle") platformType = Type.Normal;
        //if (obstacleHit.collider.tag != "Obstacle") platformType = Type.Normal;
        if (obstacleHit.collider.tag == "Obstacle") platformType = Type.Dangerous; 
    }
    /// GameObject canvas
    private void initializeCanvasWriting()
    {
         GameObject enemy = Instantiate(info, transform.position, Quaternion.identity) as GameObject;
        enemy.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, false);
    }

    public void NewDay()
    {
        if (levelOfStability != 8 && levelOfRisk - (levelOfStability * 2) >= Random.Range(0, 100) && platformType == Type.Normal)
        {
            platformType = Type.Dangerous;
            Vector3 obstaclePosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.01f);
            Instantiate(obstacle, obstaclePosition, Quaternion.identity);

            SpriteRenderer m_SpriteRenderer = GetComponent<SpriteRenderer>();
            m_SpriteRenderer.color = Color.red;
        }
        else levelOfRisk += Random.Range(1, 50) - (levelOfStability * 3);

        if (levelOfRisk > 100)
        {
            if (platformType == Type.Dangerous) Destroy(obstacleHit.collider.gameObject);
            Destroy(this.gameObject);
            Destroy(obj_productivity);    
        }
    }

    void RayHitBuiding()
    { 
        Vector3 rightVector = new Vector3(transform.position.x + 2f, transform.position.y, 0f);
        Vector3 leftVector = new Vector3(transform.position.x - 2f, transform.position.y, 0f);
        Vector3 upVector = new Vector3(transform.position.x, transform.position.y + 2f, 0f);
        Vector3 downVector = new Vector3(transform.position.x, transform.position.y  -2f, 0f);

        RaycastHit2D rightHit = Physics2D.Raycast(rightVector, Vector3.zero, 0f);
        RaycastHit2D leftHit = Physics2D.Raycast(leftVector, Vector3.zero, 0f);
        RaycastHit2D upHit = Physics2D.Raycast(upVector, Vector3.zero, 0f);
        RaycastHit2D downHit = Physics2D.Raycast(downVector, Vector3.zero, 0f);

       
        if (rightHit.collider== null && downHit.collider == null) spriteRenderer.sprite = imageIndexes[2];
        else if (leftHit.collider == null && downHit.collider == null) spriteRenderer.sprite = imageIndexes[1];
        else spriteRenderer.sprite = imageIndexes[0];

        if (spriteRenderer.sprite == imageIndexes[0]) waterEffect.SetActive(false);
        else if(spriteRenderer.sprite == imageIndexes[2])
        {
            waterEffect.transform.position = new Vector3(initPositionWater.x + 0.94f, initPositionWater.y, initPositionWater.z);
            waterEffect.transform.localScale = new Vector3(initScaleWater.x * -1f, initScaleWater.y, initScaleWater.z);
        }

        Debug.DrawRay(rightVector, Vector3.down, Color.red, 1.0f);
        Debug.DrawRay(leftVector, Vector3.down, Color.red, 1.0f);
        Debug.DrawRay(upVector, Vector3.down, Color.red, 1.0f);
        Debug.DrawRay(downVector, Vector3.down, Color.red, 1.0f);
    }


        GameObject obj_productivity;
    public void TransformPlatform(int index)
    {
        SpriteRenderer newSpriteRenderer;
        Vector3 productivityPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.01f);
        this.gameObject.GetComponent<Platform>().platformType = (Type)index;

        switch (index)
        {
            case (int)Type.Mine:
                if(playerMoney.currency.conversion() > 0.6f)
                {
                    obj_productivity = Instantiate(productivity, productivityPosition, Quaternion.identity);
                    newSpriteRenderer = obj_productivity.GetComponent<SpriteRenderer>();
                    newSpriteRenderer.sprite = typeRenderer[index];
                    playerMoney.increaseMoney += Random.Range(0.2f, 0.9f);
                    playerMoney.buyThings(0.60f); 
                }
                break;

            case (int)Type.Farm:
                if(playerMoney.currency.conversion() > 0.2f)
                {
                    obj_productivity = Instantiate(productivity, productivityPosition, Quaternion.identity);
                    newSpriteRenderer = obj_productivity.GetComponent<SpriteRenderer>();
                    newSpriteRenderer.sprite = typeRenderer[index];
                    playerMoney.increaseMoney += Random.Range(0.8f, 2f);
                    playerMoney.buyThings(0.20f);
                }

                break;

            case (int)Type.Oil:
                if(playerMoney.currency.conversion() > 2.30f)
                {
                    obj_productivity = Instantiate(productivity, productivityPosition, Quaternion.identity);
                    newSpriteRenderer = obj_productivity.GetComponent<SpriteRenderer>();
                    newSpriteRenderer.sprite = typeRenderer[index];
                    playerMoney.increaseMoney += Random.Range(1.6f, 7f);
                    playerMoney.buyThings(2.30f);
                }

                break;

            case (int)Type.House:
                if(playerMoney.currency.conversion() > 7.20f)
                {
                    obj_productivity = Instantiate(productivity, productivityPosition, Quaternion.identity);
                    newSpriteRenderer = obj_productivity.GetComponent<SpriteRenderer>();
                    newSpriteRenderer.sprite = typeRenderer[index];

                    playerMoney.increaseMoney += Random.Range(7f, 20f);
                    playerMoney.buyThings(7.20f);
                }
                break;

            default:
                break;
        }

        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Debuger Stay; " + collision.gameObject);
    }



}
