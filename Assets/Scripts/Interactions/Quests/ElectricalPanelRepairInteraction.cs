using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ElectricalPanelRepairInteraction : Interactable
{
    public event UnityAction ElectrilacPanelRepaired;

    [SerializeField] private Animator _playerAnimator;

    public override void OnInteract(InteractionCatcher interactionCatcher)
    {
        if(interactionCatcher.GetComponentInChildren<PickUpNippersInteraction>() != null)
        {
            if (IsAvailable == false)
                return;

            var nippers = interactionCatcher.GetComponentInChildren<PickUpNippersInteraction>();

            StartCoroutine(RepairElectricalPanel(nippers));
        }        
    }

    private IEnumerator RepairElectricalPanel(PickUpNippersInteraction nippers)
    {
        var playerMovement = _playerAnimator.gameObject.GetComponent<Movement>();

        playerMovement.enabled = false;
        //play player animation
        Destroy(nippers.gameObject);
        nippers.transform.parent = transform;

        yield return new WaitForSecondsRealtime(5f);

        playerMovement.enabled = true;

        ElectrilacPanelRepaired?.Invoke();

        IsAvailable = false;
    }
}
