using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RestartPowerSupplyInteraction : Interactable
{
    public event UnityAction PowerSupplyRestarted;

    [SerializeField] private MeshRenderer _bulbMeshRenderer;
    [SerializeField] private Material _greenBulbMaterial;

    public override void OnInteract(InteractionCatcher interactionCatcher)
    {
        StartCoroutine(RestartPowerSupply());
    }

    private IEnumerator RestartPowerSupply()
    {
        yield return new WaitForSecondsRealtime(5f);

        _bulbMeshRenderer.material = _greenBulbMaterial;

        PowerSupplyRestarted?.Invoke();

        IsAvailable = false;
    }
}
