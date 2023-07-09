
namespace IMG.InputSystem
{
    public class HandheldInput : InputSystem
    {
        public override void GetInput()
        {
            UpdateAxisDeviation(ref _holdForward, ref _forwardAxis);
            UpdateAxisDeviation(ref _holdBack, ref _backAxis, true);
            UpdateAxisDeviation(ref _holdLeft, ref _leftAxis, true);
            UpdateAxisDeviation(ref _holdRight, ref _rightAxis);
            UpdateAxisDeviation(ref _cameraHoldLeft, ref _leftCameraAngle, true);
            UpdateAxisDeviation(ref _cameraHoldRight, ref _rightCameraAngle);


            ConverteValuesToAxis(ref _backAxis, ref _forwardAxis, ref _inputAxis.z);
            ConverteValuesToAxis(ref _leftAxis, ref _rightAxis, ref _inputAxis.x);
            ConverteValuesToAxis(ref _leftCameraAngle, ref _rightCameraAngle, ref _cameraAngle);
        }

        private void ConverteValuesToAxis(ref float negativeValue, ref float positioveValue, ref float targetAxis)
        {
            if (negativeValue != 0)
            {
                targetAxis = negativeValue;
            }
            else if (positioveValue != 0)
            {
                targetAxis = positioveValue;
            }
            else
            {
                targetAxis = 0.0f;
            }
        }

        private void UpdateAxisDeviation(ref bool holdedStatus, ref float direction, bool negativeValue = false)
        {
            if (holdedStatus == true && negativeValue == false)
            {
                direction = 1;
            }
            else if (holdedStatus == true && negativeValue == true)
            {
                direction = -1;
            }
            else
            {
                direction = 0;
            }
        }

        public void ForwardHoldedStatus(bool holdedStatus)
        {
            _holdForward = holdedStatus;
        }

        public void BackHoldStatus(bool holdedStatus)
        {
            _holdBack = holdedStatus;
        }

        public void LeftHoldStatus(bool holdedStatus)
        {
            _holdLeft = holdedStatus;
        }

        public void RightHoldStatus(bool holdedSatatus)
        {
            _holdRight = holdedSatatus;
        }

        public void CameraLeftHoldStatus(bool holdedSatatus)
        {
            _cameraHoldLeft = holdedSatatus;
        }

        public void CameraRightHoldStatus(bool holdedSatatus)
        {
            _cameraHoldRight = holdedSatatus;
        }
    }
}
