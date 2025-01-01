using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookshelf : MonoBehaviour, IInteract
{
    [SerializeField][Multiline] private string bookshelfMessage;
    public delegate void OnScrollInteract(string message);
    public static OnScrollInteract onBookshelfllInteract;
    public void ExecuteInteract(InteractionSystem player)
    {
        onBookshelfllInteract?.Invoke(bookshelfMessage);
    }
}
