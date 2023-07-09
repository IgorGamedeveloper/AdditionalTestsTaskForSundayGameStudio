using UnityEngine;

namespace IMG.InputSystem
{
    public abstract class InputSystem : MonoBehaviour
    {
        [Header("—читывать ввод 'MovementAxis':")]
        public bool MovementAxisInput = true;

        [Space(10f)]
        [Header("—читывать ввод 'RotationAxis':")]
        public bool RotationAxisInput = true;

        [Space(10f)]
        [Header("—читывать ввод 'CameraRotateAxis':")]
        public bool CameraRotateInput = true;

        public string MovementAxisName { get; private set; } = "Vertical";
        public string RotationAxisName { get; private set; } = "Horizontal";

        public string CameraRotateAxisName { get; private set; } = "Rotary";



        protected float _forwardAxis;
        public float ForwardAxis { get { return _forwardAxis; } }

        protected float _backAxis;
        public float BackAxis { get { return _backAxis; } }

        protected float _leftAxis;
        public float LeftAxis { get { return _leftAxis; } }

        protected float _rightAxis;
        public float RightAxis { get { return _rightAxis; } }


        protected Vector3 _inputAxis;
        public Vector3 InputAxis { get { return _inputAxis; } }



        protected float _leftCameraAngle;
        public float LeftCameraAngle { get { return _leftCameraAngle; } }

        protected float _rightCameraAngle;
        public float RightCameraAngle { get { return _rightCameraAngle; } }



        protected float _cameraAngle;
        public float CameraAngle { get { return _cameraAngle; } }


        protected bool _holdForward = false;
        protected bool _holdBack = false;
        protected bool _holdLeft = false;
        protected bool _holdRight = false;

        public bool HoldForward { get { return _holdForward; } }
        public bool HoldBack { get { return _holdBack; } }
        public bool HoldLeft { get { return _holdLeft; } }
        public bool HoldRight { get { return _holdRight; } }

        protected bool _cameraHoldLeft;
        protected bool _cameraHoldRight;

        public bool CameraHoldLeft { get { return _cameraHoldLeft; } }
        public bool CameraHoldRight { get { return _cameraHoldRight; } }






        private void Update()
        {
            GetInput();
        }

        public abstract void GetInput();
    }
}
