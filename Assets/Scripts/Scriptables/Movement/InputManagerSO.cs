using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "InputManager")] 
public class InputManagerSO : ScriptableObject
{
    PlayerControls inputMapper;
    public event Action<Vector2> OnMove;
    public event Action OnInteract;
    public event Action OnPause;

    private void OnEnable()
    {
        inputMapper = new PlayerControls();
        inputMapper.Gameplay.Enable();
        inputMapper.Gameplay.Movement.started += Move;
        inputMapper.Gameplay.Movement.performed += Move;
        inputMapper.Gameplay.Movement.canceled += Move;
        inputMapper.Gameplay.Interact.started += Interact;
        inputMapper.Gameplay.Pause.started += Pause;
    }

    private void Pause(InputAction.CallbackContext obj)
    {
        OnPause?.Invoke();
    }

    private void Interact(InputAction.CallbackContext obj)
    {
        OnInteract?.Invoke();
    }

    private void Move(InputAction.CallbackContext obj)
    {
        OnMove?.Invoke(obj.ReadValue<Vector2>());
    }
}
