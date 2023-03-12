using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadarPointer : MonoBehaviour
{
    [SerializeField] private Image _image;

    private Transform _target;
    private Transform _owner;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void FixedUpdate()
    {
        UpdatePositionAndRotationOnScreen();
    }

    public void Init(Transform target, Transform owner, Sprite icon)
    {
        _target = target;
        _owner = owner;
        _image.sprite = icon;

        //_target.GetComponent<Destructible>().OnDeath.AddListener(OnTargetDeath);
    }

    private void OnTargetDeath()
    {
        //_target.GetComponent<Destructible>().OnDeath.RemoveListener(OnTargetDeath);
        Destroy(gameObject);
    }

    private void UpdatePositionAndRotationOnScreen()
    {
        Vector3 distanceFromPlayerToPlanet = _target.position - _owner.position;
        Ray ray = new Ray(_owner.position, distanceFromPlayerToPlanet);
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_camera);
        float minDistance = Mathf.Infinity;
        int planeIndex = -1;

        // 0 = Left, 1 = Right, 2 = Down, 3 = Up
        for (int i = 0; i < 4; i++)
        {
            if (planes[i].Raycast(ray, out float distance))
            {
                if (distance < minDistance)
                {
                    minDistance = distance;
                    planeIndex = i;
                }
            }
        }

        minDistance = Mathf.Clamp(minDistance, 0f, distanceFromPlayerToPlanet.magnitude);
        Vector3 worldPosition = ray.GetPoint(minDistance);
        transform.SetPositionAndRotation(_camera.WorldToScreenPoint(worldPosition), GetIconRotation(planeIndex));

        Vector3 targetPosition = _camera.WorldToScreenPoint(_target.position);
        float offset = 75f;

        if (targetPosition.x > -offset && targetPosition.x < _camera.pixelRect.width + offset
            && targetPosition.y > -offset && targetPosition.y < _camera.pixelRect.height + offset)
            _image.gameObject.SetActive(false);
        else
            _image.gameObject.SetActive(true);
    }

    private Quaternion GetIconRotation(int index)
    {
        float angle = 0f;

        switch (index)
        {
            case 0:
                angle = 90f;
                break;
            case 1:
                angle = -90f;
                break;
            case 2:
                angle = 180f;
                break;
            case 4:
                angle = 0f;
                break;
        }

        return Quaternion.Euler(0f, 0f, angle);
    }
}
