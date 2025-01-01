using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelTrigger : MonoBehaviour
{
    public delegate void OnEndLevel();
    public static OnEndLevel onEndLevel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            onEndLevel?.Invoke();
        }
    }
}
