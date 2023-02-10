using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera playerCamera;
    public Transform rightCameraPos;
    public Transform leftCameraPos;
    public Transform currentPos;
    bool defaultRight = true;
    bool cameraLock = false;
    bool switchStarted = false;
    float time = 0f;
    Vector3 playerGlobalPos;


    private void Start()
    {
        if (defaultRight) currentPos = rightCameraPos;
        playerCamera.transform.position = currentPos.position;


    }
    void SwitchCameras(bool cameraLock) {
        if (!cameraLock)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                if (currentPos == rightCameraPos) currentPos = leftCameraPos;
                else currentPos = rightCameraPos;
                switchStarted = true;
            }
        }
    }

    void LerpCameraPositon(bool switchStarted) {

        if (switchStarted)
        {
            time += Time.deltaTime / 2f;
            float distance = (currentPos.position - playerCamera.transform.position).sqrMagnitude;
            playerCamera.transform.position = Vector3.Lerp(playerCamera.transform.position, currentPos.position, Mathf.SmoothStep(0,1,time));

            if(distance <= 0.03f)
            {
                time = 0f;
                playerCamera.transform.position = currentPos.position;
                switchStarted = false;
            }
        }
    }
    private void UpdateCameraRotation()
    {
        playerGlobalPos = GetComponentInParent<PlayerMovement>().gameObject.transform.position;
        //renderer.SetPositions(new Vector3[] {playerCamera.transform.position, playerGlobalPos});
        Quaternion.LookRotation((playerGlobalPos - playerCamera.transform.position));
    }

    private void Update()
    {
        UpdateCameraRotation();
        SwitchCameras(cameraLock);
        LerpCameraPositon(switchStarted);

    }

    
}
