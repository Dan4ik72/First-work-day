using System.Collections;
using UnityEngine;

public class ElectricalPanelRepairInteraction : Interactable
{
    [SerializeField] private GameObject _nippers;
    [SerializeField] private Animator _playerAnimator;

    private Vector3 _startPosition;
    private Quaternion _startRotation;

    private void Start()
    {
        _startPosition = _nippers.transform.position;
        _startRotation = _nippers.transform.rotation;
    }

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
        nippers.transform.parent = transform;
        nippers.gameObject.SetActive(false);

        yield return new WaitForSecondsRealtime(3f);

        playerMovement.enabled = true;
        IsAvailable = false;
    }

    public override void ResetByDefault()
    {
        base.ResetByDefault();
        _nippers.SetActive(true);
        _nippers.transform.position = _startPosition;
        _nippers.transform.rotation = _startRotation;
    }
}
