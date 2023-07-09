using UnityEngine;

namespace IMG.InputSystem
{
    public class KeyboardInput : InputSystem
    {
        public override void GetInput()
        {
            _inputAxis.x = Input.GetAxisRaw(RotationAxisName);

            _inputAxis.z = Input.GetAxisRaw(MovementAxisName);

            _cameraAngle = Input.GetAxis(CameraRotateAxisName);
        }
    }
}
