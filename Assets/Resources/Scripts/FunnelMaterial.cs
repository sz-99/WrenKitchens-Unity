using UnityEngine;

public class FunnelMaterial : MonoBehaviour
{
    public Vector2 textureTiling = new Vector2(1,1);
    private Material fibreMaterial;
    private Material rustMaterial;
    private Renderer funnelRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        funnelRenderer = GetComponent<MeshRenderer>();
        fibreMaterial = fibreMaterial ?? Resources.Load<Material>("Assets/Resources/Materials/Tilable_Scratched.mat");
        rustMaterial = rustMaterial ?? Resources.Load<Material>("Assets/Resources/Materials/Tilable_Fibre.mat");
        funnelRenderer.material = rustMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
