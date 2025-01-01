using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorRotation : MonoBehaviour, IInteract
{


    private bool playerInRange = false;
    public enum DoorType { Left, Right }
    public enum OpenDirection { Inward, Outward }
    [Header("References and Values")]
    [SerializeField] private DoorType doorType;
    [SerializeField] private OpenDirection openDirection;
    [SerializeField] private bool IsUnopenable = false;
    [SerializeField] private GameObject keyNeeded;

    public delegate void OnDoorInteract(string type);
    public static OnDoorInteract doorIsBlocked;
    public static OnDoorInteract doorNeedsAKey;

    public float rotationSpeed = 3f;
    public float interactionDistance = 2f;

    private bool isOpen = false;
    private float initialAngle; // Ángulo inicial de la puerta
    private float targetAngle;
    private float currentAngle;
    [SerializeField] private AudioClip lockedClip;
    private AudioSource source;

    private void Start()
    {
        // Guardar el ángulo inicial de la puerta
        source = GetComponent<AudioSource>();
        initialAngle = transform.localEulerAngles.z;
        currentAngle = initialAngle;
        targetAngle = initialAngle;
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;

        // Calcular el ángulo objetivo sumando o restando al ángulo inicial
        float angleOffset = (doorType == DoorType.Left) ? -90f : 90f;
        if (openDirection == OpenDirection.Inward) angleOffset *= -1;
        targetAngle = initialAngle + angleOffset;
        StartCoroutine(Rotate());
    }

    public void ExecuteInteract(InteractionSystem player)
    {
        if (IsUnopenable)
        {
            doorIsBlocked?.Invoke("Unopenable");
            source.PlayOneShot(lockedClip);
        }
        else if (keyNeeded != null)
        {
            doorNeedsAKey?.Invoke(keyNeeded.name);
            source.PlayOneShot(lockedClip);
        }
        else
        {
            ToggleDoor();
            this.gameObject.tag = "Untagged";
        }
    }

    private IEnumerator Rotate()
    {
        while (currentAngle != targetAngle)
        {
            // Interpolar el ángulo actual hacia el ángulo objetivo
            currentAngle = Mathf.Lerp(currentAngle, targetAngle, rotationSpeed * Time.deltaTime);

            // Aplicar la rotación usando localEulerAngles
            transform.localEulerAngles = new Vector3(0f, 0f, currentAngle);
            yield return null;
        }
    }
}
