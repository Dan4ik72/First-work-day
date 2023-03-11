using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCMover : MonoBehaviour
{
    public event UnityAction TargetPointReached;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed = 2f;

    private Transform _targetPoint;

    private Vector3 _currentDirection;

    public bool IsWalking { get; private set; }

    private void FixedUpdate()
    {
        if (_targetPoint == null)
            return;

        if (Vector3.Distance(transform.position, _targetPoint.position) < 0.5f)
        {
            IsWalking = false;

            _targetPoint = null;

            TargetPointReached?.Invoke();

            return;
        }

        Move();
        Rotate();
    }

    public void SetTargetPoint(Transform targetPoint)
    {
        _targetPoint = targetPoint;
    }

    private void Move()
    {
        IsWalking = true;

        _currentDirection = _targetPoint.position - transform.position;

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(_targetPoint.position.x, transform.position.y, _targetPoint.position.z), _moveSpeed * Time.deltaTime);
    }

    private void Rotate()
    {
        Quaternion rotation = Quaternion.LookRotation(new Vector3(_currentDirection.x, 0f, _currentDirection.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
    }
}
