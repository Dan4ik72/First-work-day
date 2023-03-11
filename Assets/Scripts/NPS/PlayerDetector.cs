using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CheckIfPlayer(other);
    }

    private void CheckIfPlayer(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            if (Physics.Raycast(transform.parent.position, (player.transform.position - transform.parent.position), out RaycastHit hit) == true)
            {
                if (hit.transform.TryGetComponent<Player>(out Player p) == true)
                {
                    Game.Instance.ShowSpottedPanel();
                    Debug.Log(hit.transform.name);
                    OnPlayerEntered();
                }
            }
        }
    }

    private void OnPlayerEntered()
    {
        Debug.Log("Oh nooo");
    }
}
