using System;
using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player_movements : MonoBehaviour
{
    float speed = 2f;
    Vector3 movement;

    // Update is called once per frame
    void Update()
    {
        int _kCodeA = -Convert.ToInt16(Input.GetKey(KeyCode.A));
        int _kCodeD = Convert.ToInt16(Input.GetKey(KeyCode.D));
        int _kCodeW = Convert.ToInt16(Input.GetKey(KeyCode.W));
        int _kCodeS = -Convert.ToInt16(Input.GetKey(KeyCode.S));

        int inputX = (_kCodeA + _kCodeD);
        int inputY = (_kCodeW + _kCodeS);

        movement = new Vector3(speed * inputX, speed * inputY, 0);
        if (RayHitWithPlatform(inputX, inputY)) transform.position += movement * Time.deltaTime;
    }


    int CanMove(bool canMove)
    {
        return Convert.ToInt16(canMove);
    }

    bool RayHitWithPlatform(int inputX, int inputY) {
        Vector3 rayCast = new Vector3(0.3f * inputX, 0.3f * inputY, 0); 

        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayCast, 10.0f);
        Debug.DrawRay(transform.position, rayCast,  Color.green, 10.0f);

        Debug.Log(hit.collider);
        if (hit.collider.tag == "Platform") return true;
        else return false;
    }
}


