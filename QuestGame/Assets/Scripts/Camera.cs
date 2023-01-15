using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private float cameraX, cameraY, cameraZ;
    private Transform transform;
    private Transform playerTransform;
    [SerializeField] private float mouseSensitivity = 2;

    void Awake()
    {
        transform = GetComponent<Transform>();
        playerTransform = FindObjectOfType<Player>().GetComponent<Transform>();
        cameraX = 0;
        cameraY = 0;
        cameraZ = 0;

        //Cursor settings
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
     
        cameraX = Mathf.Clamp(cameraX - mouseY * mouseSensitivity, -70f, 70f);
        cameraY = transform.rotation.eulerAngles.y;
        cameraZ = transform.rotation.eulerAngles.z;

        float playerX = playerTransform.rotation.eulerAngles.x;
        float playerY = playerTransform.rotation.eulerAngles.y + mouseX * mouseSensitivity;
        float playerZ = playerTransform.rotation.eulerAngles.z;

        transform.rotation = Quaternion.Euler(cameraX, cameraY, cameraZ);
        playerTransform.rotation = Quaternion.Euler(playerX, playerY, playerZ);
    }
}
