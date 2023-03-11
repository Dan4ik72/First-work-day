using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCTriggerReactor : MonoBehaviour
{
    public UnityAction NPCArrived;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out NPC npc))
        {
            NPCArrived?.Invoke();
        }
    }
}
