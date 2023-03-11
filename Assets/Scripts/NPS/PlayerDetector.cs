using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            OnPlayerEntered();
        }
    }

    private void OnPlayerEntered()
    {
        Debug.Log("Oh nooo");
    }
}
