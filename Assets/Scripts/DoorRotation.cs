using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorRotation : MonoBehaviour
{


    private bool playerInRange = false;
    public enum DoorType { Left, Right }
    public enum OpenDirection { Inward, Outward }

    [SerializeField] private DoorType doorType;
    [SerializeField] private OpenDirection openDirection;
    public float rotationSpeed = 3f;
    public float interactionDistance = 2f;
    public string conditionScriptName = "ExternalConditionScript";

    private bool isOpen = false;
    private float initialAngle; // �ngulo inicial de la puerta
    private float targetAngle;
    private float currentAngle;

    private void Start()
    {
        // Guardar el �ngulo inicial de la puerta
        initialAngle = transform.localEulerAngles.z;
        currentAngle = initialAngle;
        targetAngle = initialAngle;
    }

    private void Update()
    {

        GameObject player = GameObject.FindWithTag("Player");

        if (Keyboard.current.eKey.wasPressedThisFrame) // Detectar la tecla "E"
        {
            // Verificar si el jugador est� cerca
            
            if (player != null && Vector3.Distance(transform.position, player.transform.position) <= interactionDistance)
            {
                ToggleDoor();
                // Verificar la condici�n externa
                MonoBehaviour conditionScript = player.GetComponent(conditionScriptName) as MonoBehaviour;
                if (conditionScript != null && conditionScript.enabled && (bool)conditionScript.GetType().GetMethod("CheckCondition").Invoke(conditionScript, null))
                {
                    //ToggleDoor(); // Abrir/cerrar la puerta
                }
            }
        }

        // Interpolar el �ngulo actual hacia el �ngulo objetivo
        currentAngle = Mathf.Lerp(currentAngle, targetAngle, rotationSpeed * Time.deltaTime);

        // Aplicar la rotaci�n usando localEulerAngles
        transform.localEulerAngles = new Vector3(0f, 0f, currentAngle);
        
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;

        // Calcular el �ngulo objetivo sumando o restando al �ngulo inicial
        float angleOffset = (doorType == DoorType.Left) ? -90f : 90f;
        if (openDirection == OpenDirection.Inward) angleOffset *= -1;
        targetAngle = initialAngle + angleOffset;
    }
}
