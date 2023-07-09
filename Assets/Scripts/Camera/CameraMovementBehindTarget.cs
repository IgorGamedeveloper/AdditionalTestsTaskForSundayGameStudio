using UnityEngine;

public class CameraMovementBehindTarget : MonoBehaviour
{
    [Header("Цель камеры:")]
    [SerializeField] private Transform _target;

    [Space(10f)]
    [Header("Высота камеры")]
    [SerializeField] private float _cameraHeight = 5.0f;

    [Space(10f)]
    [SerializeField] private float _distanceToTarget = 15.0f;

    [Space(10f)]
    [Header("Сглаживание движения по высоте:")]
    [SerializeField] private float _heightSmooth = 2.0f;

    [Space(10f)]
    [SerializeField] private float _rotateSmooth = 3.0f;


    private float _currentHeight;
    private float _currentRotateAngleX;
    private float _currentRotateAngleY;

    private float _targetHeight;
    private float _targetRotateAngleX;
    private float _targetRotateAngleY;

    private Quaternion _currentRotation;

    private Vector3 _targetPosition;



    void LateUpdate()
    {
        _currentHeight = transform.position.y;
        _currentRotateAngleX = transform.eulerAngles.x;
        _currentRotateAngleY = transform.eulerAngles.y;

        _targetHeight = _target.position.y + _cameraHeight;
        _targetRotateAngleX = _target.eulerAngles.x;
        _targetRotateAngleY = _target.eulerAngles.y;

        _currentHeight = Mathf.Lerp(_currentHeight, _targetHeight, _heightSmooth * Time.deltaTime);

        _currentRotateAngleX = Mathf.LerpAngle(_currentRotateAngleX, _targetRotateAngleX, _rotateSmooth * Time.deltaTime);
        _currentRotateAngleY = Mathf.LerpAngle(_currentRotateAngleY, _targetRotateAngleY, _rotateSmooth * Time.deltaTime);

        _currentRotation = Quaternion.Euler(_currentRotateAngleX, _currentRotateAngleY, 0);
        _targetPosition = _target.position - _currentRotation * Vector3.forward * _distanceToTarget;
        _targetPosition.y = _currentHeight;

        transform.position = _targetPosition;
        transform.rotation = _currentRotation;
    }
}
