using UnityEngine;

namespace IMG.InputSystem
{
    public class PlayerInputSystem : MonoBehaviour
    {
        public InputSystem TargetInputSystem { get; private set; }


        public enum AllInputSystem
        {
            Keyboard,
            Handheld,
            Joystick
        }

        [SerializeField] private AllInputSystem _currentInputSystem = AllInputSystem.Keyboard;
        public AllInputSystem CurrentInputSystem { get { return _currentInputSystem; } }

        [Header("���������� ��� ����������� � ����������� �� ����������:")]
        [SerializeField] private bool _autodetectedInputSystem = true;

        [Space(25f)]
        [Header("��������� �������:")]
        public bool DebugLog = false;



        private void Awake()
        {
            if (_autodetectedInputSystem == true)
            {
                CheckDeviceType();
            }

            ChangeInputSystemType(CurrentInputSystem);
        }

        private void CheckDeviceType()
        {
            if (SystemInfo.deviceType == DeviceType.Desktop)
            {
                _currentInputSystem = AllInputSystem.Keyboard;
            }
            else if (SystemInfo.deviceType == DeviceType.Handheld)
            {
                _currentInputSystem = AllInputSystem.Handheld;
            }
            else if (SystemInfo.deviceType == DeviceType.Console)
            {
                _currentInputSystem = AllInputSystem.Joystick;
            }

            Debug.Log($"������� ���������� {CurrentInputSystem}");
        }

        public void ChangeInputSystemType(AllInputSystem currentInputSystem)
        {
            switch (currentInputSystem)
            {
                case AllInputSystem.Keyboard:
                    if (gameObject.TryGetComponent(out KeyboardInput keyboardInput) == false)
                    {
                        TargetInputSystem = gameObject.AddComponent<KeyboardInput>();
                    }
                    else
                    {
                        TargetInputSystem = keyboardInput;
                    }
                    break;

                case AllInputSystem.Handheld:
                    if (gameObject.TryGetComponent(out HandheldInput handheldInput) == false)
                    {
                        TargetInputSystem = gameObject.AddComponent<HandheldInput>();
                    }
                    else
                    {
                        TargetInputSystem = handheldInput;
                    }
                    break;

                case AllInputSystem.Joystick:
                default:
                    if (gameObject.TryGetComponent(out keyboardInput) == false)
                    {
                        TargetInputSystem = gameObject.AddComponent<KeyboardInput>();
                    }
                    else
                    {
                        TargetInputSystem = keyboardInput;
                    }

                    break;
            }
        }
    }
}
