using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    [SerializeField] private InputManagerSO inputManger;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private Transform feet;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float speed;
    [SerializeField] private float gravityFactor;
    [SerializeField] private float radiusDetection;

    // Private Values
    private CharacterController characterController;
    private Vector3 inputDirection;
    private Vector3 movementDirection;
    private Vector3 verticalVelocity;

    private void OnEnable()
    {
        inputManger.OnMove += Move;
    }
    private void OnDestroy()
    {
        inputManger.OnMove -= Move;
    }

    private void Move(Vector2 obj)
    {
        inputDirection = new Vector3(obj.x, 0, obj.y);
        RotateToDestination(movementDirection);
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Application.targetFrameRate = 60;
        characterController = this.gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = playerCamera.forward * inputDirection.z + playerCamera.right *  inputDirection.x;
        movementDirection.y = 0;
        characterController.Move(movementDirection * speed * Time.deltaTime);

        if(IsOnGround() && verticalVelocity.y < 0)
        {
            verticalVelocity.y = 0;
        }

        ApplyGravity();
    }

    private void RotateToDestination(Vector3 destination)
    {
        Quaternion targetRotation = Quaternion.LookRotation(destination);
        transform.rotation = targetRotation;
    }

    private bool IsOnGround()
    {
        return Physics.CheckSphere(feet.position, radiusDetection, groundLayer);

    }

    private void ApplyGravity()
    {
        verticalVelocity.y += gravityFactor * Time.deltaTime;
        characterController.Move(verticalVelocity * Time.deltaTime);
    }
}
