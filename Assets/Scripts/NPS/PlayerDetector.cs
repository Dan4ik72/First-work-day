using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("test");
        if(other.TryGetComponent(out Player player))
        {
            Debug.Log("test2");

            if(Physics.Raycast(transform.position, player.transform.position , out RaycastHit hit) == false)
            {
                OnPlayerEntered();  
            }
        }
    }

    private void OnPlayerEntered()
    {
        Debug.Log("Oh nooo");
    }
}
