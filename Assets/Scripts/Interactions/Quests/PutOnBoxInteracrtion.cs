using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PutOnBoxInteracrtion : Interactable
{
    [SerializeField] private GameObject _block;
    [SerializeField] private AudioSource _audioSource;

    private Vector3 _startPosition;
    private Quaternion _startRotation;

    public event UnityAction BoxPuttedOn;

    private void Start()
    {
        _startPosition = _block.transform.position;
        _startRotation = _block.transform.rotation;
    }

    public override void OnInteract(InteractionCatcher interactionCatcher)
    {
        if (interactionCatcher.gameObject.GetComponentInChildren<PickUpBlockInteraction>() != null && IsAvailable == true)
        {
            _audioSource.Play();
            var block = interactionCatcher.gameObject.GetComponentInChildren<PickUpBlockInteraction>();

            block.transform.parent = transform;
            block.gameObject.SetActive(false);

            BoxPuttedOn?.Invoke();

            IsAvailable = false;
        }
    }

    public override void ResetByDefault()
    {
        base.ResetByDefault();
        _block.SetActive(true);
        _block.transform.parent = null;
        _block.transform.position = _startPosition;
        _block.transform.rotation = _startRotation;
    }
}
