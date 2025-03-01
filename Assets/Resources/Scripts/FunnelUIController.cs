using UnityEngine;
using UnityEngine.UIElements;

public class FunnelUIController : MonoBehaviour
{
    public VisualTreeAsset funnelUIAsset;
    private ProceduralFunnel funnelScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>().rootVisualElement;
        funnelScript = FindFirstObjectByType<ProceduralFunnel>();

        Slider topDSlider = uiDocument.Q<Slider>("TopDiameter");
        Slider bottomDSlider = uiDocument.Q<Slider>("BottomDiameter");
        Slider slopeHSlider = uiDocument.Q<Slider>("SlopeHeight");
        Slider tubeHSlider = uiDocument.Q<Slider>("TubeHeight");
        Slider segmentsSlider = uiDocument.Q<Slider>("Segments");

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
