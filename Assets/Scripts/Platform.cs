using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public enum Type { Normal, Dangerous, Mine, Farm, Oil, House};

    public int levelOfRisk = 10;
    public Type platformType = Type.Normal;

    public int levelOfStability = 0; // 7: Max Stability. 

    private PlayerMoney playerMoney;

    /// <summary>
    ///  Sprite management
    /// </summary>

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] imageIndexes;
    [SerializeField] private GameObject waterEffect;
    [SerializeField] private GameObject obstacle;


    private Vector3 initPositionWater;
    private Vector3 initScaleWater;

    RaycastHit2D obstacleHit; 
    private void Start()
    {
        levelOfRisk = Random.Range(1, 99);
        playerMoney = GameObject.Find("player").GetComponent<PlayerMoney>();

        spriteRenderer.sprite = imageIndexes[0];


        initPositionWater = waterEffect.transform.position;
        initScaleWater = waterEffect.transform.localScale;
    }

    private void Update()
    {
        RayHitBuiding();

        if (Input.GetKeyDown(KeyCode.L)) NewDay();
        obstacleHit = Physics2D.Raycast(transform.position, Vector3.zero, 0f);
        if (obstacleHit.collider.tag != "Obstacle") platformType = Type.Normal; 
    }

    public void NewDay()
    {
        if (levelOfStability != 7 && levelOfRisk - (levelOfStability * 2) >= Random.Range(0, 100) && platformType != Type.Dangerous)
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
            if (obstacleHit.collider.tag == "Obstacle") Destroy(obstacleHit.collider.gameObject);
            Destroy(this.gameObject);
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

       
        if (rightHit.collider == null && downHit.collider == null) spriteRenderer.sprite = imageIndexes[2];
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


    public void TransformPlatform(Type type)
    {
        Color color; 
        switch(type)
        {
            case Platform.Type.Mine:
                color = Color.black;
                break;

            case Platform.Type.Farm:
                color = Color.green;
                break;

            case Platform.Type.Oil:
                color = Color.yellow;
                break;

            default:
                color = Color.white;
                break;
        }


        SpriteRenderer m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteRenderer.color = color;
        platformType = type;
        playerMoney.currency.quantity -= 0.01f; 
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Debuger Stay; " + collision.gameObject);
    }

}
