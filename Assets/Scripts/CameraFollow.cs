using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 10f;
    public Vector3 offset;

    private void LateUpdate()
    {
        offset = new Vector3(0, 0, -10);
        Vector3 cameraPosition = target.position + offset;
        Vector3 smoothTransform = Vector3.Lerp(transform.position, cameraPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothTransform;
    }
    private float horizontalResolution = Screen.width;

    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 2;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame 
    // TODO: Fix with a better code. -- Unnecessary code and conditions 
    void Update()
    {
        QualitySettings.vSyncCount = 2;
        Application.targetFrameRate = 60;

        Screen.SetResolution(1920, 1080, true, 60);
    }

}
