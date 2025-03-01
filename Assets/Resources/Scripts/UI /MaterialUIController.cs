using UnityEngine;
using UnityEngine.UIElements;

public class MaterialUIController : MonoBehaviour
{
    public VisualTreeAsset MaterialUIAsset;
    private FunnelMaterial material;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var uiDocument = GetComponent<UIDocument>();
        if (uiDocument == null)
        {
            Debug.LogError("UIDocument component not found.");
            return;
        }
        material = FindFirstObjectByType<FunnelMaterial>();
        if (material == null)
        {
            Debug.LogError("FunnelMaterial not found!");
            return;
        }

        var root = uiDocument.rootVisualElement;

        Button rustButton = root.Q<Button>("MetallicRustMaterial");
        Button fibreButton = root.Q<Button>("MetallicFibreMaterial");
        if(rustButton == null || fibreButton == null)
        {
            Debug.LogError("One or more buttons not found.");
        }
        rustButton.clicked += material.ApplyFibreMaterial;
        fibreButton.clicked += material.ApplyRustMaterial;

        Slider tilingSlider = root.Q<Slider>("TilingSlider");
        tilingSlider.RegisterValueChangedCallback(evt=>material.SetTextureScale(evt.newValue));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
