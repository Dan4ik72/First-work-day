using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTriggerAfterExplosion : MonoBehaviour
{
    [SerializeField] public NPCMover NPCMover;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out NPC npc))
        {
            NPCMover.enabled = false;
        }
    }
}
