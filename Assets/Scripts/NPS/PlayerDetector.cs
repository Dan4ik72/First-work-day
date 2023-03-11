using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            RaycastHit hit;

            if(Physics.Raycast(transform.position, player.transform.position , out hit))
            {
                if(hit.collider.gameObject.TryGetComponent(out Player hittenPlayer))
                    OnPlayerEntered();  
            }
        }
    }

    private void OnPlayerEntered()
    {
        Debug.Log("Oh nooo");
    }
}
