using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 55;
    [SerializeField] private float _stopSpeed = 1;
    [SerializeField] private Vector3 _limitVelocity = new Vector3(4f, 4f, 4f);
    [SerializeField] private float _visualModelRotationSpeed = 10f;

    private Rigidbody _rigidbody;
    private float _horizontalSpeed;
    private float _verticalSpeed;
    private Vector3 _targetSpeed;

    public bool IsMoving => _rigidbody.velocity != Vector3.zero;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnDisable()
    {
        _rigidbody.velocity = Vector3.zero;
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
            transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, _visualModelRotationSpeed);
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
