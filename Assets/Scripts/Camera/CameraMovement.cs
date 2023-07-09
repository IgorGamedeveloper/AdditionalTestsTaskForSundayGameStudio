using UnityEngine;
using IMG.InputSystem;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    //  _________________________________________________________________   КОМПОНЕНТЫ КАМЕРЫ:
    private InputSystem _inputSystem;

    [SerializeField] private Transform _currentTarget;


    //  _________________________________________________________________   ПАРАМЕТРЫ КАМЕРЫ:

    [Header("Параметры камеры:")]

    [Space(15f)]
    [Header("Скорость вращения камеры:")]
    [SerializeField] private float _rotationSpeed = 8f;

    [Space(10f)]
    [Header("Угол наклона камеры.")]
    [SerializeField] private float _upperAngle = 40f;

    [Space(10f)]
    [Header("Растояние от камеры до цели.")]
    [SerializeField] private float _distance = 25f;

    private float _horizontalRotation;

    private Quaternion _targetRotation;
    private Vector3 _negativeDistance;
    private Vector3 _targetPosition;

    private bool _rotation;
    private float _rotateInput;


    [Space(25f)]
    [Header("Активно ли авто вращение:")]
    [SerializeField] private bool _canAutoRotate = true;
    [Space(10f)]
    [Header("Параметры задержки по времени перед началом автовращения:")]
    [SerializeField] private float _handlerAutoRotateTime = 3f;
    private bool _autoRotate = true;
    private IEnumerator AutoRotateEnumerator;
    private float _rotateSideMemory = 1f;

    private delegate void RotateMethod();
    private RotateMethod CurrentRotateMethod;





    //  ###################################################################   ИНИЦИАЛИЗАЦИЯ:

    private void Start()
    {
        _inputSystem = FindObjectOfType<PlayerInputSystem>().TargetInputSystem;

        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            CurrentRotateMethod = PCRotation;
        }
        else if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            CurrentRotateMethod = AndroidRotation;
        }
    }

    //  _________________________________________________________________   ПЕРЕМЕЩЕНИЕ КАМЕРЫ:

    void LateUpdate()
    {
        CurrentRotateMethod();
    }

    private void PCRotation()
    {
        if (_canAutoRotate == true)
        {
            if (_inputSystem.CameraAngle != 0)
            {
                if (_inputSystem.CameraAngle < 0)
                {
                    _rotateSideMemory = -1.0f;
                }
                else
                {
                    _rotateSideMemory = 1.0f;
                }

                DeativateAutoRotate();
            }
        }

        if (_canAutoRotate == true && _autoRotate == true)
        {
            Rotate(_rotateSideMemory);
        }
        else
        {
            if (_currentTarget != null)
            {
                Rotate(_inputSystem.CameraAngle);
            }
        }
    }

    private void AndroidRotation()
    {
        if (_rotation == false)
        {
            if (_canAutoRotate == true)
            {
                DeativateAutoRotate();
            }
        }

        if (_canAutoRotate == true && _autoRotate == true)
        {
            Rotate(_rotateSideMemory);
        }
        else
        {
            Rotate(_rotateInput);
        }
    }

    private void Rotate(float input)
    {
        _horizontalRotation += input * _rotationSpeed * _distance * Time.deltaTime;

        _targetRotation = Quaternion.Euler(_upperAngle, _horizontalRotation, 0f);

        _negativeDistance = new Vector3(0f, 0f, -_distance);

        _targetPosition = _targetRotation * _negativeDistance + _currentTarget.position;

        transform.rotation = _targetRotation;
        transform.position = _targetPosition;

        transform.position = _currentTarget.position - transform.forward * _distance;
    }

    public void DeativateAutoRotate()
    {
        if (AutoRotateEnumerator != null)
        {
            StopCoroutine(AutoRotateEnumerator);
            AutoRotateEnumerator = null;
        }

        AutoRotateEnumerator = null;
        AutoRotateEnumerator = AutoRotateDeactivateTimer(_handlerAutoRotateTime);
        StartCoroutine(AutoRotateDeactivateTimer(_handlerAutoRotateTime));
    }

    private IEnumerator AutoRotateDeactivateTimer(float timeDelay)
    {
        _autoRotate = false;

        yield return new WaitForSeconds(timeDelay);

        _autoRotate = true;
    }

    public void StartRotateButton(float input)
    {
        _rotation = true;
        _rotateInput = input;
        _rotateSideMemory = input;
    }

    public void EndRoatateButton()
    {
        _rotation = false;
    }
}
