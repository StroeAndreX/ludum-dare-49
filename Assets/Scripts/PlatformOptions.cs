using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformOptions : MonoBehaviour
{
    public int index;
    // 0: Farm
    // 1: Mine
    // 2: Oil
    // 3: House

    public Sprite[] sprites; 
    private SpriteRenderer spriteRenderer;

    private PlayerMoney pMoney = new PlayerMoney();
    public int selectedPlatformLevel;

    [SerializeField] GameObject productivityObj;
    public Productivity accessProductivity;

    private AudioSource _audioSource;
    [SerializeField] GameObject connectedLabel;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[index];

        pMoney = GameObject.Find("player").GetComponent<PlayerMoney>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D mouseHit = Physics2D.Raycast(worldPosition, Vector3.zero, 0f);

        if (mouseHit.collider != null)
        {

            if (mouseHit.collider.gameObject == this.gameObject)
            {
                this.spriteRenderer.color = Color.yellow;
                if (Input.GetMouseButtonUp(0))
                {

                    int index = this.gameObject.GetComponent<PlatformOptions>().index;
                    if (selectedPlatformLevel < 4 && index == 1) return;
                    else if (selectedPlatformLevel < 6 && index == 2) return;
                    else if (selectedPlatformLevel < 10 && index == 3) return;
                    Platform platformController = pMoney.selectedPlatform.GetComponent<Platform>();

                    platformController.TransformPlatform(index);
                    _audioSource.Play();
                    Debug.Log("I did not an uupsie");
                }

            }
            else
            {
                this.spriteRenderer.color = Color.white;
            }
        }
        if (Input.GetMouseButtonUp(0)) pMoney.ResetFunction();

        if (pMoney.selectedPlatform != null)
        {
            Platform platform = pMoney.selectedPlatform.GetComponent<Platform>();
            Debug.Log("Debug Log Level: " + platform.levelOfStability);
            selectedPlatformLevel = platform.levelOfStability;

            if (selectedPlatformLevel < 4 && index == 1) spriteRenderer.sprite = sprites[4];
            else if (selectedPlatformLevel < 6 && index == 2) spriteRenderer.sprite = sprites[4];
            else if (selectedPlatformLevel < 10 && index == 3) spriteRenderer.sprite = sprites[4];
            else spriteRenderer.sprite = sprites[index];

         
        }

    }
}


/*
 *  Platform alterPlatform = pMoney.selectedPlatform.GetComponent<Platform>();
                    Vector3 productivityPosition = new Vector3(alterPlatform.transform.position.x, alterPlatform.transform.position.y, -5f);
                    if (alterPlatform.productivityAccess != null) return;

                    productivityObj = Instantiate(productivityObj, productivityPosition, Quaternion.identity);
                    Productivity productivity = productivityObj.GetComponent<Productivity>();
                    productivity.index = this.index;

                    alterPlatform.SetProductivity(productivityObj);

                    return;*/