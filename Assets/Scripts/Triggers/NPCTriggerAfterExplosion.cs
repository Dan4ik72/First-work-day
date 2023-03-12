using UnityEngine;

public class NPCTriggerAfterExplosion : MonoBehaviour
{
    [SerializeField] public NPCMover NPCMover;
    [SerializeField] public CuratorMoveState CuratorMoveState;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out NPC npc))
        {
            NPCMover.enabled = false;
            CuratorMoveState.IsMoving = false;
        }
    }
}
