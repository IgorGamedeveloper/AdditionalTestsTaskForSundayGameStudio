using UnityEngine;

public class CarMaterialsStorage : MonoBehaviour
{
    public static CarMaterialsStorage Instance { get; private set; }

    private static Material[] _materials;





    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    public void SaveMeshMaterials(MeshRenderer _meshRenderer)
    {
        _materials = _meshRenderer.materials;
    }

    public Material[] LoadMaterials()
    {
        return _materials;
    }
}
