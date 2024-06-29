using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    //private bool playerInRange = false;
    public float interactionDistance = 2f;
    public TextMeshProUGUI interactionText;
    public float moveSpeed;
    public float climbSpeed;
    public float gravity = -9.81f;
    public CharacterController controller;
    public InputActionReference move;
    public Transform cameraTransform;
    private List<DoorRotation> doors = new List<DoorRotation>(); // Lista de scripts de puertas
    private DoorRotation nearestDoorScript; // Script de la puerta más cercana

    private Vector2 moveInput;
    private Vector3 velocity;
    private bool isClimbing;

    private void Start()
    {
        // Encontrar todos los scripts de puertas en la escena
        doors.AddRange(FindObjectsOfType<DoorRotation>());
    }

    private void Update()
    {
        moveInput = move.action.ReadValue<Vector2>();
        isClimbing = DetectStairs();


        // Encontrar la puerta más cercana
        nearestDoorScript = null;
        float closestDistance = Mathf.Infinity;
        foreach (DoorRotation door in doors)
        {
            float distance = Vector3.Distance(transform.position, door.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearestDoorScript = door;
            }
        }

        // Mostrar/ocultar el mensaje según si el jugador está cerca de alguna puerta
        if (interactionText != null)
        {
            interactionText.gameObject.SetActive(nearestDoorScript != null && closestDistance <= interactionDistance);
        }

        if (Keyboard.current.eKey.wasPressedThisFrame && nearestDoorScript != null && closestDistance <= interactionDistance)
        {
            // Abrir/cerrar la puerta más cercana
            nearestDoorScript.ToggleDoor();
        }

    }

    private void FixedUpdate()
    {
        // Calcular la dirección de movimiento en relación a la cámara
        Vector3 moveDirection = cameraTransform.right * moveInput.x + cameraTransform.forward * moveInput.y;
        moveDirection.y = 0f; // Mantener el movimiento en el plano horizontal

        // Normalizar la dirección para evitar movimientos más rápidos en diagonal
        moveDirection.Normalize();

        // Aplicar gravedad si no está en el suelo
        if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }

        // Aplicar movimiento horizontal y vertical
        Vector3 finalMove = moveDirection * moveSpeed + velocity;
        controller.Move(finalMove * Time.deltaTime);

        // Reiniciar la velocidad vertical si está en el suelo
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }
    }

    private bool DetectStairs()
    {
        // (Tu lógica de detección de escaleras aquí)
        return false;
    }
}
