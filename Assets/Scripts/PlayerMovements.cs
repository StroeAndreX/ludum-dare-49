using System;
using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovements : MonoBehaviour
{
    float speed = 2f;
    Vector3 movement;

    public int inputX { get; set; } 
    public int inputY { get; set; }

    public GameObject sittingPlatform; 

    // Update is called once per frame
    void Update()
    {
        int _kCodeA = -Convert.ToInt16(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow));
        int _kCodeD = Convert.ToInt16(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow));
        int _kCodeW = Convert.ToInt16(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow));
        int _kCodeS = -Convert.ToInt16(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow));

        inputX = (_kCodeA + _kCodeD);
        inputY = (_kCodeW + _kCodeS);

        Debug.Log(inputX);
        movement = new Vector3(speed * inputX, speed * inputY, 0);
        if (RayHitWithPlatform()) transform.position += movement * Time.deltaTime;
    }

    bool RayHitWithPlatform() {
        Vector3 rayCast = new Vector3(0.3f * inputX, 0.3f * inputY, 0); 

        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayCast, 10.0f);
        Debug.DrawRay(transform.position, rayCast,  Color.green, 10.0f);

        if (hit.collider.tag == "Platform")
        {
            sittingPlatform = hit.collider.gameObject;
            return true;
        }
        else return false;
    }

    
}


