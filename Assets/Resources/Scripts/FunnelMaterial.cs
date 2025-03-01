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
        fibreMaterial = Resources.Load<Material>("Materials/Tilable_Scratched");
        rustMaterial = Resources.Load<Material>("Materials/Tilable_Fibre");

        if (funnelRenderer == null)
        {
            Debug.LogError("MeshRenderer not found on object!");
            return;
        }

        if (rustMaterial == null || fibreMaterial == null)
        {
            Debug.LogError("One or both materials failed to load. Check Resources folder path!");
            return;
        }

        funnelRenderer.material = rustMaterial;
        funnelRenderer.material.mainTextureScale = textureTiling;
    }

    public void ApplyFibreMaterial()
    {
        if (funnelRenderer != null && fibreMaterial != null)
        {
            funnelRenderer.material = fibreMaterial;
        }
    }

    public void ApplyRustMaterial()
    {
        if (funnelRenderer != null && rustMaterial != null)
        {
            funnelRenderer.material = rustMaterial;
        }
    }
}
