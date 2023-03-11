using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _camera;

    [SerializeField] private float _zoomStep = 2f;
    [SerializeField] private float _zoomDampening = 7.5f;
    [SerializeField] private float _zoomMinHeight = 5f;
    [SerializeField] private float _zoomMaxHeight = 50f;
    [SerializeField] private float _zoomSpeed = 2f;

    private float _zoomHeight;

    private void Start()
    {
        _zoomHeight = _camera.localPosition.y;
    }

    private void Update()
    {
        float input = Input.GetAxis("Mouse ScrollWheel");
        if (input != 0)
            Zoom(input);
    }

    private void FixedUpdate()
    {
        transform.position = _target.position;
        UpdateCameraPosition();
    }

    private void Zoom(float inputValue)
    {
        if (Mathf.Abs(inputValue) > 0.01f)
        {
            _zoomHeight = _camera.localPosition.y + inputValue * _zoomStep;
            _zoomHeight = Mathf.Clamp(_zoomHeight, _zoomMinHeight, _zoomMaxHeight);
        }
    }

    private void UpdateCameraPosition()
    {
        Vector3 target = new Vector3(_camera.localPosition.x, _zoomHeight, _camera.localPosition.z);
        target -= _zoomSpeed * (_zoomHeight - _camera.localPosition.y) * Vector3.forward;
        _camera.localPosition = Vector3.Lerp(_camera.localPosition, target, _zoomDampening * Time.deltaTime);
        _camera.LookAt(transform);
    }

}
