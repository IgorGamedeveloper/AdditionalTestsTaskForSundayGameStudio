using IMG.InputSystem;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarMovement : MonoBehaviour
{

    private PlayerInputSystem _playerInputSystem;
    private InputSystem _inputSystem;
    private Rigidbody _rigidbody;

    [SerializeField] private float _forwardMoveSpeed = 25.0f;
    [SerializeField] private float _maxForwardSpeed = 30.0f;
    private bool _moveForward;

    [SerializeField] private float _backMoveSpeed = 15.0f;
    [SerializeField] private float _maxBackSpeed = 20.0f;
    private bool _moveBack;

    private float _currentSpeed;
    private float _currentMaxSpeed;


    [SerializeField] private float _rotateSpeed = 8.0f;
    private bool _rotate;
    private float _rotateMultiplier = -1f;


    [SerializeField] private Vector3 _centerOfMassOffset;







    private void Start()
    {
        _playerInputSystem = FindObjectOfType<PlayerInputSystem>();
        _inputSystem = _playerInputSystem.TargetInputSystem;
        _rigidbody = GetComponent<Rigidbody>();

        _rigidbody.centerOfMass = _rigidbody.centerOfMass - _centerOfMassOffset;
    }

    private void Update()
    {
        _inputSystem.GetInput();
        PlayerInput();
    }

    private void PlayerInput()
    {
        if (_inputSystem.InputAxis.z > 0)
        {
            _moveForward = true;
            _rotateMultiplier = 1.0f;
        }
        else
        {
            _moveForward = false;
        }

        if (_inputSystem.InputAxis.z < 0)
        {
            _moveBack = true;
            _rotateMultiplier = -1.0f;
        }
        else
        {
            _moveBack = false;
        }

        if (_inputSystem.InputAxis.x != 0)
        {
            _rotate = true;
        }
        else
        {
            _rotate = false;
        }
    }

    private void FixedUpdate()
    {
        if (_moveForward == true)
        {
            StraightMove(_inputSystem.InputAxis.z);
        }

        if (_moveBack == true)
        {
            StraightMove(_inputSystem.InputAxis.z);
        }

        if (_rotate == true)
        {
            Rotate(_inputSystem.InputAxis.x);
        }
    }

    private void StraightMove(float directionAxis)
    {
        if (directionAxis > 0)
        {
            _currentSpeed = _forwardMoveSpeed;
            _currentMaxSpeed = _maxForwardSpeed;
        }
        else if (directionAxis < 0)
        {
            _currentSpeed = _backMoveSpeed;
            _currentMaxSpeed = _backMoveSpeed;
        }

        _rigidbody.AddRelativeForce(Vector3.forward * directionAxis * _currentSpeed, ForceMode.Acceleration);

        if (_rigidbody.velocity.magnitude > _currentMaxSpeed)
        {
            _rigidbody.velocity = _rigidbody.velocity.normalized * _currentMaxSpeed;
        }
    }

    private void Rotate(float angleRotate)
    {
        _rigidbody.AddRelativeTorque(Vector3.up * angleRotate * _rotateSpeed * _rotateMultiplier, ForceMode.Acceleration);

        if (_rigidbody.angularVelocity.magnitude > _rotateSpeed)
        {
            _rigidbody.angularVelocity = Vector3.up * _rotateSpeed;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        if (_rigidbody != null)
        {
            Gizmos.DrawSphere(_rigidbody.centerOfMass, 0.4f);
        }
    }
}
