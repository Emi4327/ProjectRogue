using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XInput;

public class RotateTowardsMousePos : MonoBehaviour
{
    private Camera playerCamera;
    private InputManager inputManager;
    [SerializeField] private float rotationOffset = -90;

    private void Start()
    {
        playerCamera = Camera.main.GetComponentInChildren<Camera>();
        inputManager = GetComponentInParent<InputManager>();
    }
    private void Update()
    {
        Vector3 mousePosition = playerCamera.ScreenToWorldPoint(inputManager.GetMousePosition());
        mousePosition.z = 0f;

        Vector3 direction = mousePosition - transform.position;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if(mousePosition.x >= transform.position.x && transform.localScale.x>0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else if(transform.localScale.x < 0 && mousePosition.x < transform.position.x)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        if(transform.lossyScale.x <= 0f)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + rotationOffset + 180f));
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + rotationOffset));
        }
    }
}
