using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    public float speed = 4f;
    private bool attack = false;

    Transform enemy;

    // Start is called before the first frame update
    void Start()
    {
        _particleSystem = this.GetComponent<ParticleSystem>();
        enemy = GetClosestEnemy();
    }

    void ArcMove(Vector3 startPos, Vector3 targetPos, float arcHeight)
    {
        float distCovered = speed; // (Time.time - startTime) * (15f * Time.deltaTime); 
        float distance = Vector3.Distance(startPos, targetPos);
        //float fractionOfJurney = (distCovered / distance) * Time.deltaTime;

        transform.position = Vector3.Lerp(transform.position, new Vector3(targetPos.x, targetPos.y, startPos.z), speed * Time.deltaTime);
    }

    private void Update()
    {
        if (enemy == null) Destroy(this.gameObject);
        ArcMove(transform.position, enemy.position, 1f);
    }

    Transform GetClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Obstacle");
        if (enemies.Length <= 0) return null; 

        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject t in enemies)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = t.transform;
                minDist = dist;
            }
        }

        if (tMin.gameObject.activeInHierarchy == false) return null;

        return tMin;
    }

    Color origionalColor;
    public SpriteRenderer SpriteRenderer;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" || other.tag == "Obstacle")
        {
            foreach(GameObject bullet in GameObject.FindGameObjectsWithTag("Bullet")) Destroy(bullet);
            other.GetComponent<Obstacles>().hp -= Random.Range(3.3f, 30.5f);
        }
    }




}
