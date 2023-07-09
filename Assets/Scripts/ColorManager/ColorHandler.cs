using UnityEngine;

public class ColorHandler : MonoBehaviour
{
    public static ColorHandler Instance { get; private set; }

    [Header("Материал кабины, для изменения цвета:")]
    [SerializeField] private Material _cabineMaterial;

    [Space(10f)]
    [Header("Материал кузова, для изменения цвета:")]
    [SerializeField] private Material _bodyMaterial;

    [Space(15f)]
    [Header("Цвет кабины при старте:")]
    [SerializeField] private Color _cabineColor = Color.gray;
    [Space(10f)]
    [Header("Цвет кузова при старте:")]
    [SerializeField] private Color _bodyColor = Color.blue;


    [Space(20f)]
    [Header("Изменять ли цвет определенной части машины:")]
    public bool ChangeCabineColor = true;
    public bool ChangeBodyColor = false;





    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        ChangeMaterialColor(ref _cabineMaterial, _cabineColor);
        ChangeMaterialColor(ref _bodyMaterial, _bodyColor);
    }

    public void CanChangeCabineColor()
    {
        ChangeCabineColor = !ChangeCabineColor;
        Debug.Log($"Изменять цвет кабины: ChangeCabine = {ChangeCabineColor}");
    }

    public void CanChangeBodyColor()
    {
        ChangeBodyColor = !ChangeBodyColor;
        Debug.Log($"Изменять цвет кузова: ChangeBody = {ChangeBodyColor}");
    }

    private void OnMouseDown()
    {
        ChangeColors();
    }

    private void ChangeColors()
    {
        if (ChangeCabineColor == true)
        {
            ChangeMaterialColor(ref _cabineMaterial, GetRandomColor(ref _cabineColor));
        }

        if (ChangeBodyColor == true)
        {
            ChangeMaterialColor(ref _bodyMaterial, GetRandomColor(ref _bodyColor));
        }
    }

    private Color GetRandomColor(ref Color colorField)
    {
        colorField = new Color(Random.value, Random.value, Random.value, 1f);

        return colorField;
    }

    public void ChangeMaterialColor(ref Material material, Color color)
    {
        material.color = color;
    }
}
