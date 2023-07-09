using UnityEngine;

public class UIAdapter : MonoBehaviour
{
    [Header("Обьекты которые будут активированны на платформе 'Android':")]
    [SerializeField] private GameObject[] _enableOnAndroid;

    [Space(10f)]
    [Header("Обьекты которые будут активированны на платформе 'PC':")]
    [SerializeField] private GameObject[] _disableOnAndroid;

    [Space(20f)]
    [Header("Отладка:")]
    public bool ShowDebugLog = false;



    private void Start()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            ActivateForAndroid(false);
        }
        else if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            ActivateForAndroid(true);
        }
    }

    private void ActivateForAndroid(bool activate)
    {
        if (_enableOnAndroid != null && _enableOnAndroid.Length > 0)
        {
            for (int i = 0; i < _enableOnAndroid.Length; i++)
            {
                _enableOnAndroid[i].SetActive(activate);

                if (ShowDebugLog == true)
                {
                    Debug.Log($"{_enableOnAndroid[i]} - SetActive:({activate})");
                }
            }
        }

        if (_disableOnAndroid != null && _disableOnAndroid.Length > 0)
        {
            for (int i = 0; i < _disableOnAndroid.Length; i++)
            {
                _disableOnAndroid[i].SetActive(!activate);

                if (ShowDebugLog == true)
                {
                    Debug.Log($"{_disableOnAndroid[i]} - SetActive:({!activate})");
                }
            }
        }
    }
}
