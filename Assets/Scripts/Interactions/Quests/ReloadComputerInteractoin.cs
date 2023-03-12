using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReloadComputerInteractoin : Interactable
{
    public event UnityAction ComputerReloaded;

    [SerializeField] private MeshRenderer[] _screenMeshRenderers;
    [SerializeField] private Material _doneMaterial;
    [SerializeField] private Material _startMaterial;
    [SerializeField] private AudioSource _audioSource;

    public override void OnInteract(InteractionCatcher interactionCatcher)
    {
        if (IsAvailable == false)
            return;

        StartCoroutine(ReloadComputer());
    }

    private IEnumerator ReloadComputer()
    {
        _audioSource.Play();

        yield return new WaitForSecondsRealtime(2.5f);

        foreach (var screen in _screenMeshRenderers)
        {
            screen.material = _doneMaterial;
        }

        ComputerReloaded?.Invoke();
        IsAvailable = false;
    }

    public override void ResetByDefault()
    {
        base.ResetByDefault();

        foreach (var screen in _screenMeshRenderers)
        {
            screen.material = _startMaterial;
        }
    }
}
