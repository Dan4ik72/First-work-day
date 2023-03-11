using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReloadComputerInteractoin : Interactable
{
    public event UnityAction ComputerReloaded;

    [SerializeField] private MeshRenderer _screenMeshRenderer;
    [SerializeField] private Material _material;

    private void Awake()
    {
        _screenMeshRenderer = GetComponent<MeshRenderer>();
    }

    public override void OnInteract(InteractionCatcher interactionCatcher)
    {
        if (IsAvailable == false)
            return;

        StartCoroutine(ReloadComputer());
    }

    private IEnumerator ReloadComputer()
    {
        yield return new WaitForSecondsRealtime(5f);

        _screenMeshRenderer.material = _material;
        ComputerReloaded?.Invoke();

        IsAvailable = false;
    }
}
