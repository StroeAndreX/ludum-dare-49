using UnityEngine;
using System.Collections;

public class PlayerPower : MonoBehaviour
{
    PlayerMovements pMove = new PlayerMovements();
    [SerializeField] Sprite sprite;
    GameObject powerRadiusMouse;
    GameObject powerRadius;

    private void Start()
    {
        // Find the PlayerObject
        GameObject playerObject = GameObject.Find("player");
        pMove = playerObject.GetComponent<PlayerMovements>();

        /// Line Renderer
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = 0.02f;
        lineRenderer.positionCount = 2;
    }


    private void Update()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();


        if (Input.GetKeyDown(KeyCode.Z))
        {
            // Vector3 playerPos = new Vector3(transform.position.x, transform.position.y, 0f);
            powerRadius = new GameObject("PowerRadius");
            powerRadius.AddComponent<SpriteRenderer>().sprite = sprite;

            // Draw circle
            powerRadiusMouse = new GameObject("PowerRadiusMouse");
            powerRadiusMouse.AddComponent<SpriteRenderer>().sprite = sprite;
            Vector3 scaleChange = new Vector3(0.1f, 0.1f, 1f);
            powerRadiusMouse.transform.localScale = scaleChange;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 0f);
            /// Draw line
            lineRenderer.positionCount = 2; 
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, mousePos);

            // Check the distance between circle and player
            float dist = Vector3.Distance(mousePos, transform.position);
            print("Distance to other: " + dist);

            /// Circle that follow the mouse
            if(dist < 10.55f) powerRadiusMouse.transform.position = new Vector3(mousePos.x, mousePos.y, -.1f);
            powerRadius.transform.position = new Vector3(transform.position.x, transform.position.y, -.09f);

            if (Input.GetMouseButtonDown(0) && IsWalkableZone(hit))
            {
                if (dist < 10.55f) transform.position = new Vector3(mousePos.x, mousePos.y, 0f);
                Debug.Log("With great power comes great responsabilities");
            }
        }

        if(Input.GetKeyUp(KeyCode.Z))
        {
            Destroy(powerRadius);
            Destroy(powerRadiusMouse);

            lineRenderer.positionCount = 0; 
        }

    }

    private bool IsWalkableZone(RaycastHit2D hit)
    {
        if (hit.collider.tag == "Platform" || hit.collider.tag == "Homebase") return true; 

        return false;
    }

}


// RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos, Vector2.zero, 0f);
//foreach (RaycastHit2D hit in hits) {
//    Debug.Log(hit.collider.name);
//}
