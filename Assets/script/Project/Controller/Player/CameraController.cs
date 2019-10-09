using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed = 20.0f;
    public float sensibilidade = 2.0f;
    public bool travar = false;

    private float mouseX, mouseY;
    // Use this for initialization

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX += Input.GetAxis("Mouse X");
        mouseY += Input.GetAxis("Mouse Y");
        
        transform.position = Vector3.Lerp(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        if (!travar)
        {
            transform.eulerAngles = new Vector3(mouseY, mouseX, 0);
        }
    }
}