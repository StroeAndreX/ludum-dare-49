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

    private void Start()
    {
        levelOfRisk = Random.Range(1, 99);
        playerMoney = GameObject.Find("player").GetComponent<PlayerMoney>();
    }

    private void Update()
    {

    }

    public void NewDay()
    {
        if (levelOfStability != 7 && levelOfRisk - (levelOfStability * 2) >= Random.Range(0, 100))
        {
            platformType = Type.Dangerous;
            SpriteRenderer m_SpriteRenderer = GetComponent<SpriteRenderer>();
            m_SpriteRenderer.color = Color.red;
        }
        else levelOfRisk += Random.Range(1, 50) - (levelOfStability * 3);

        if (levelOfRisk > 100) Destroy(this.gameObject);
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

}
