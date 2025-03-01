using UnityEngine;
using UnityEngine.UIElements;

public class FunnelUIController : MonoBehaviour
{
    public VisualTreeAsset funnelUIAsset;
    private ProceduralFunnel funnelScript;

 

    void Start()
{
    var uiDocument = GetComponent<UIDocument>();
    if (uiDocument == null)
    {
        Debug.LogError("UIDocument component not found.");
        return;
    }

    var root = uiDocument.rootVisualElement;
    if (root == null)
    {
        Debug.LogError("rootVisualElement is null. Check if the UI Document is correctly assigned.");
        return;
    }

    funnelScript = FindFirstObjectByType<ProceduralFunnel>();

    Slider topDSlider = root.Q<Slider>("TopDiameter");
    Slider bottomDSlider = root.Q<Slider>("BottomDiameter");
    Slider slopeHSlider = root.Q<Slider>("SlopeHeight");
    Slider tubeHSlider = root.Q<Slider>("TubeHeight");
    Slider segmentsSlider = root.Q<Slider>("Segments");

    if (topDSlider == null || bottomDSlider == null || slopeHSlider == null || tubeHSlider == null || segmentsSlider == null)
    {
        Debug.LogError("One or more sliders are not found in the UI Document.");
        return;
    }

    topDSlider.value = funnelScript.GetTopDiameter();
    bottomDSlider.value = funnelScript.GetBottomDiameter();
    slopeHSlider.value = funnelScript.GetSlopingHeight();
    tubeHSlider.value = funnelScript.GetTubeHeight();
    segmentsSlider.value = funnelScript.GetSegments();

    topDSlider.RegisterValueChangedCallback(evt => UpdateFunnel());
    bottomDSlider.RegisterValueChangedCallback(evt => UpdateFunnel());
    slopeHSlider.RegisterValueChangedCallback(evt => UpdateFunnel());
    tubeHSlider.RegisterValueChangedCallback(evt => UpdateFunnel());
    segmentsSlider.RegisterValueChangedCallback(evt => UpdateFunnel());
}


    // Update is called once per frame
    void Update()
    {
        
    }

    

    void UpdateFunnel()
    {
        var uiDocument = GetComponent<UIDocument>().rootVisualElement;
        funnelScript = FindFirstObjectByType<ProceduralFunnel>();

        Slider topDSlider = uiDocument.Q<Slider>("TopDiameter");
        Slider bottomDSlider = uiDocument.Q<Slider>("BottomDiameter");
        Slider slopeHSlider = uiDocument.Q<Slider>("SlopeHeight");
        Slider tubeHSlider = uiDocument.Q<Slider>("TubeHeight");
        Slider segmentsSlider = uiDocument.Q<Slider>("Segments");

        funnelScript.UpdateFunnel(
            topDSlider.value,
            bottomDSlider.value,
            slopeHSlider.value,
            tubeHSlider.value,
            (int)segmentsSlider.value
        );
    }

}
