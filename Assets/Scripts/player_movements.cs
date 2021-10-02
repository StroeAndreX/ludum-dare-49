using System;
using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player_movements : MonoBehaviour
{
    float speed = 2f;
    Vector3 movement; 

    // Start is called before the first frame update
    void Start()
    {   
        
    }

    // Update is called once per frame
    void Update()
    {
        int _kCodeA = -Convert.ToInt16(Input.GetKey(KeyCode.A));
        int _kCodeD = Convert.ToInt16(Input.GetKey(KeyCode.D));
        int _kCodeW = Convert.ToInt16(Input.GetKey(KeyCode.W));
        int _kCodeS = -Convert.ToInt16(Input.GetKey(KeyCode.S));

        int inputX = _kCodeA + _kCodeD;
        int inputY = _kCodeW + _kCodeS; 

        movement = new Vector3(speed * inputX, speed * inputY, 0);
        transform.position += movement * Time.deltaTime; 
    } 
}
