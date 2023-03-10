using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _stopSpeed = 1;
    [SerializeField] private Vector3 _limitVelocity;
    [SerializeField] private Transform _visualModelTransform;

    private Rigidbody _rigidbody;
    private float _horizontalSpeed;
    private float _verticalSpeed;
    private Vector3 _targetSpeed;
    private float _visualModelRotationSpeed = 15f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _horizontalSpeed = Input.GetAxisRaw("Horizontal") * _speed;
        _verticalSpeed = Input.GetAxisRaw("Vertical") * _speed;

        Move();
    }

    private void Move()
    {
        _targetSpeed = new Vector3(_horizontalSpeed * Time.fixedDeltaTime, 0f, _verticalSpeed * Time.fixedDeltaTime);

        if (_targetSpeed != Vector3.zero)
        {
            _rigidbody.velocity += _targetSpeed;
            LimitVelocity(_limitVelocity);

            var angle = Quaternion.Euler(new Vector3(0, -Vector3.SignedAngle(_rigidbody.velocity, Vector3.forward, Vector3.up)));
            _visualModelTransform.rotation = Quaternion.RotateTowards(_visualModelTransform.rotation, angle, _visualModelRotationSpeed);
        }
        else
        {
            _rigidbody.velocity = Vector3.MoveTowards(_rigidbody.velocity, Vector3.zero, _stopSpeed);
        }
    }

    private void LimitVelocity(Vector3 limit)
    {
        if (_rigidbody.velocity.magnitude > limit.magnitude)
            _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, limit.magnitude);
    }
}
