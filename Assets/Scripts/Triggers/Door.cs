using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class Door : MonoBehaviour
{
    [SerializeField] private Transform _model;

    private BoxCollider _boxCollider;
    private Coroutine _coroutine;

    private bool _isOpen;
    private bool _isRotating;
    private int _persInTrigger;


    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _boxCollider.isTrigger = true;
        _persInTrigger = 0;
    }

    private void Update()
    {
        if (!_isRotating)
        {
            if (_persInTrigger > 0 && !_isOpen)
            {
                if (_coroutine != null)
                    StopCoroutine(_coroutine);

                _coroutine = StartCoroutine(Rotate(true));
            }

            if (_persInTrigger < 1 && _isOpen)
            {
                if (_coroutine != null)
                    StopCoroutine(_coroutine);

                _coroutine = StartCoroutine(Rotate(false));
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        _persInTrigger++;
    }

    private void OnTriggerExit(Collider other)
    {
        _persInTrigger--;
    }


    private IEnumerator Rotate(bool isOpening)
    {
        _isRotating = true;
        float currentTime = 0;
        float rotationTime = 1;
        float openValue = -85;

        float startRotationY = _model.rotation.y;
         float targetRotation = isOpening ? openValue : 0;
        Quaternion rotation = _model.rotation;
        while (currentTime < rotationTime)
        {
            currentTime += Time.deltaTime;

            rotation.y = Mathf.MoveTowards(startRotationY, targetRotation, currentTime / rotationTime);
            _model.rotation = rotation;

            yield return null;
        }
        _isOpen = isOpening;
        _isRotating = false;
    }
}
