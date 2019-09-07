using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField]float Speed = 4f;
    [SerializeField] float xClamp;
    [SerializeField] float yClamp;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float positionYawFactor = 3.5f;
    [SerializeField] float controlRollFactor = -25f;

    float xThrow, yThrow;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Translate();
        Rotate();
    }


    private void Translate()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * Speed * Time.deltaTime;
        float yOffset = yThrow * Speed * Time.deltaTime;

        float NewXPos = Mathf.Clamp(transform.localPosition.x + xOffset, -xClamp, xClamp);
        float NewYPos = Mathf.Clamp(transform.localPosition.y + yOffset, -yClamp - 1, yClamp);

        transform.localPosition = new Vector3(NewXPos, NewYPos, transform.localPosition.z);
    }

    private void Rotate()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
    
}
