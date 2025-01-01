using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour, IInteract
{
    
    [SerializeField][Multiline] private string scrollMessage;
    public delegate void OnScrollInteract(string message);
    public static OnScrollInteract onScrollInteract;
    public void ExecuteInteract(InteractionSystem player)
    {
        onScrollInteract?.Invoke(scrollMessage);
    }
}
